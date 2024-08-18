using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebBEArtGallery.Models.Dtos;

namespace WebBEArtGallery.Data.Entities
{
    public class Artwork
    {
        public Artwork(){}

        public Artwork(ArtworkDTO artwork)
        {
            if (artwork == null)
                throw new ArgumentNullException(nameof(artwork));

            Title = artwork.Name;
            CreationDate = artwork.CreationDate;
            Type = artwork.Type;
            Description = artwork.Description;
            EstimatedValue = artwork.EstimatedValue;
        }

        public void UpdateArtwork(ArtworkDTO artwork)
        {
            if (artwork == null)
                throw new ArgumentNullException(nameof(artwork));

            Title = artwork.Name;
            CreationDate = artwork.CreationDate;
            Type = artwork.Type;
            Description = artwork.Description;
            EstimatedValue = artwork.EstimatedValue;
            ArtistId = artwork.Artist_Code;
            GalleryId = artwork.Gallery_Code;
        }



        [Key]
        public int ArtworkId { get; set; }  // Primary Key

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public DateTime? CreationDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        [ForeignKey("Gallery")]
        public int? GalleryId { get; set; }
        public virtual Gallery Gallery { get; set; }

        [ForeignKey("Artist")]
        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public decimal? EstimatedValue { get; set; }
    }
}