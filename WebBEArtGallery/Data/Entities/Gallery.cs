using System;
using System.Collections.Generic;

namespace WebBEArtGallery.Data.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }  // Primary Key
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}