using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Culture
{
    public class CultureItemCreateDto
    {
        [Display(Name = "Image Item")]
        public IFormFile ImageItemFile { get; set; }
        [Display(Name = "Title Item")]
        public string TitleItem { get; set; }
        public int? CultureId { get; set; }
        public string CultureStringId { get; set; }
    }
}
