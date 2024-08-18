using System;
using System.Linq;
using System.Web.Http;
using WebBEArtGallery.Data.Entities;
using WebBEArtGallery.Data;
using WebBEArtGallery.Models.Dtos;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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

        // PUT: api/artists/{id}
        [HttpPut, Route("UpdateArtist/{id:int}")]
        public IHttpActionResult UpdateArtist(int id, [FromBody] ArtistDTO updatedArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artist = db.Artists.SingleOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

           
            artist.Name = updatedArtist.Artist_Name;
            artist.BirthDate = updatedArtist.Artist_BirthDate;
            artist.DeathDate = updatedArtist.Artist_DeathDate;
            artist.Nationality = updatedArtist.Artist_Nationality;
            artist.Biography = updatedArtist.Artist_Biography;

            // Actualizar el contexto de la base de datos
            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Artist updated");
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Any(e => e.ArtistId == id);
        }
    }
}
