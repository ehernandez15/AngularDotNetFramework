using System;
using System.Linq;
using System.Web.Http;
using WebBEArtGallery.Data;
using WebBEArtGallery.Data.Entities;
using WebBEArtGallery.Models.Dtos;
using System.Data.Entity;

namespace WebBEArtGallery.Controllers.API
{
    [RoutePrefix("api/Galleries")] //Set a custom route prefix for the API Controller. default Route Prefix= Controller name, Ex. api/GalleryAPI

    public class GalleryAPIController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        [HttpPost, Route("CreateGallery")]//Set a custom route for the endpoint 
        public IHttpActionResult CreateGallery(GalleryDTO createGalleryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Convert DTO to Entity
                var gallery = new Gallery
                {
                    Name = createGalleryDto.GalleryName,
                    Location = createGalleryDto.GalleryAddress,
                    EstablishmentDate = createGalleryDto.GalleryDateOfEstablishment,
                    Description = createGalleryDto.GalleryDescription,

                    //Just for practice, the Galleries will be able to be created with a set of Artworks
                    Artworks = createGalleryDto.Exhibited_Artworks.Select(aw => new Artwork(aw)).ToList()
                };

                db.Galleries.Add(gallery);
                db.SaveChanges();

                // Convert Entity to DTO for response
                var galleryDto = new GalleryDTO
                {
                    Id = gallery.GalleryId,
                    GalleryName = gallery.Name,
                    Exhibited_Artworks = gallery.Artworks.Select(aw => new ArtworkDTO(aw)).ToList()
                };

                return Ok(galleryDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        public IHttpActionResult GetGalleries()
        {
            try
            {
                var galleries = db.Galleries.Include(g => g.Artworks).ToList();

                var galleriesDtos = galleries.Select(g => new GalleryDTO
                {
                    Id = g.GalleryId,
                    GalleryName = g.Name,
                    Exhibited_Artworks = g.Artworks.Select(aw => new ArtworkDTO(aw)).ToList()
                }).ToList();

                return Ok(galleriesDtos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
