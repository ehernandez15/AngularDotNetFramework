using System;
using System.Collections.Generic;
using System.Linq;
using WebBEArtGallery.Data.Entities;

namespace WebBEArtGallery.Models.Dtos
{
    public class ArtistDTO
    {
        public ArtistDTO() { }

        // Constructor that takes an Artwork model as a parameter
        public ArtistDTO(Artist artist)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            Id = artist.ArtistId;
            Artist_Name = artist.Name;
            Artist_BirthDate = artist.BirthDate;
            Artist_DeathDate = artist.DeathDate;
            Artist_Nationality = artist.Nationality;
            Artist_Biography = artist.Biography;
            Created_Artworks = artist.Artworks.Select(aw => new ArtworkDTO(aw)).ToList();
        }

        public int Id { get; set; }  
        public string Artist_Name { get; set; }
        public DateTime? Artist_BirthDate { get; set; }
        public DateTime? Artist_DeathDate { get; set; }
        public string Artist_Nationality { get; set; }
        public string Artist_Biography { get; set; }
        public List<ArtworkDTO> Created_Artworks { get; set; }
    }
}