using System;
using System.Collections.Generic;
using WebBEArtGallery.Models.Dtos;


namespace WebBEArtGallery.Data.Entities
{
    public class Artist
    {
        public Artist() { }

        public Artist(ArtistDTO artist)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));

            Name = artist.Artist_Name;
            BirthDate = artist.Artist_BirthDate;
            DeathDate = artist.Artist_DeathDate;
            Nationality = artist.Artist_Nationality;
            Biography = artist.Artist_Biography;
        }


        public int ArtistId { get; set; }  // Primary Key
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Nationality { get; set; }
        public string Biography { get; set; }

        // Navigation Property
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}