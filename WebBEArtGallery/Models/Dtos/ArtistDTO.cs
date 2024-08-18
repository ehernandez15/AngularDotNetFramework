using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBEArtGallery.Models.Dtos
{
    public class ArtistDTO
    {
        public string Artist_Name { get; set; }
        public DateTime? Artist_BirthDate { get; set; }
        public DateTime? Artist_DeathDate { get; set; }
        public string Artist_Nationality { get; set; }
        public string Artist_Biography { get; set; }
        public List<ArtworkDTO> Created_Artworks { get; set; }
    }
}