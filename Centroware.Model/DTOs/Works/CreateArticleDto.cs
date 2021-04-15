using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Works
{
   public class CreateArticleDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        [Display(Name = "Image Article")]
        public IFormFile ImageFile { get; set; }
        public string WorkStringId { get; set; }
        [Display(Name = "Description Article")]
        public string Description { get; set; }
        public int? WorkId { get; set; }
    }
}
