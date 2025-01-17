﻿using System;
using System.Collections.Generic;

namespace WebBEArtGallery.Models.Dtos
{
    public class GalleryDTO
    {
        public int Id { get; set; } 
        public string GalleryName { get; set; }
        public string GalleryAddress { get; set; }
        public DateTime? GalleryDateOfEstablishment { get; set; }
        public string GalleryDescription { get; set; }

        public List<ArtworkDTO> Exhibited_Artworks { get; set; }
    }
}