using System;
using System.Collections.Generic;


namespace WebBEArtGallery.Data.Entities
{
    public class Artist
    {
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