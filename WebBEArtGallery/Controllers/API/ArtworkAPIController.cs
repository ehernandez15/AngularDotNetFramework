using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebBEArtGallery.Data;
using WebBEArtGallery.Data.Entities;
using WebBEArtGallery.Models.Dtos;

namespace WebBEArtGallery.Controllers.API
{
    [RoutePrefix("api/Artworks")] 
    public class ArtworkAPIController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        [HttpPost, Route("CreateArtwork")]//Set a custom route for the endpoint 
        public IHttpActionResult CreateArtwork(ArtworkDTO createArtworkDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Convert DTO to Entity
                var artwork = new Artwork(createArtworkDTO);

                db.Artworks.Add(artwork);
                db.SaveChanges();

                // Convert Entity to DTO for response
                var artoworkDTO = new ArtworkDTO(artwork);

                return Ok(artwork);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet, Route("")]
        public IHttpActionResult GetArtworks()
        {
            try
            {
                var artworks = db.Artworks.ToList();

                var artworksDTO = artworks.Select(a => new ArtworkDTO(a)).ToList();

                return Ok(artworksDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPut, Route("UpdateArtwork/{id:int}")]
        public IHttpActionResult UpdateArtwork(int id, [FromBody] ArtworkDTO updatedArtwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artwork = db.Artworks.SingleOrDefault(a => a.ArtworkId == id);
            if (artwork == null)
            {
                return NotFound();
            }

            artwork.UpdateArtwork(updatedArtwork);

            db.Entry(artwork).State = EntityState.Modified;

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

            return Ok("Artwork updated");
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Any(e => e.ArtistId == id);
        }
    }
}
