using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebBEArtGallery.Data.Entities;

namespace WebBEArtGallery.Models.Dtos
{
    public class ArtworkDTO
    {
        public ArtworkDTO(){}

        // Constructor that takes an Artwork model as a parameter
        public ArtworkDTO(Artwork artwork)
        {
            if (artwork == null)
                throw new ArgumentNullException(nameof(artwork));

            Id = artwork.ArtworkId;
            Name = artwork.Title;
            CreationDate = artwork.CreationDate;
            Type = artwork.Type;
            Description = artwork.Description;
            EstimatedValue = artwork.EstimatedValue;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Gallery_Code { get; set; }
        public int? Artist_Code { get; set; }
        public decimal? EstimatedValue { get; set; }
    }
}