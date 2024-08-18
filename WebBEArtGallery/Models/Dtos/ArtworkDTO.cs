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
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Gallery_Code { get; set; }
        public int? Artist_Code { get; set; }
        public decimal? EstimatedValue { get; set; }
    }
}