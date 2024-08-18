using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBEArtGallery.Data.Entities;
using WebBEArtGallery.Data;
using WebBEArtGallery.Models.Dtos;
using System.Data.Entity;

namespace WebBEArtGallery.Controllers.API
{
    [RoutePrefix("api/Artists")] //Set a custom route prefix for the API Controller. default Route Prefix= Controller name, Ex. api/GalleryAPI
    public class ArtistAPIController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        [HttpPost, Route("CreateArtist")]//Set a custom route for the endpoint 
        public IHttpActionResult CreateGallery(ArtistDTO createArtistDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Convert DTO to Entity
                var artist = new Artist(createArtistDTO);

                db.Artists.Add(artist);
                db.SaveChanges();

                // Convert Entity to DTO for response
                var artistDTO = new ArtistDTO(artist);

                return Ok(artistDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        public IHttpActionResult GetArtists()
        {
            try
            {
                var artists = db.Artists.Include(a => a.Artworks).ToList();

                var artistDtos = artists.Select(a => new ArtistDTO(a)).ToList();

                return Ok(artistDtos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
