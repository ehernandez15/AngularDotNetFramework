using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBEArtGallery.Models.Dtos
{
    public class GalleryDTO
    {
        public string GalleryName { get; set; }
        public string GalleryAddress { get; set; }
        public DateTime? GalleryDateOfEstablishment { get; set; }
        public string GalleryDescription { get; set; }

        public List<ArtworkDTO> Exhibited_Artworks { get; set; }
    }
}