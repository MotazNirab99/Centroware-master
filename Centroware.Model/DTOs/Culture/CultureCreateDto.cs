using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Culture
{
    public class CultureCreateDto
    {
        [Display(Name = "Culture Image")]
        public IFormFile MainImageFile { get; set; }
        [Display(Name = "Title ")]

        [Required(ErrorMessage = "Title is required")]
        public string Titel { get; set; }
        public string Description { get; set; }
        [Display(Name = "Title Link")]

        public string TitelLink { get; set; }
        public string CultureStringId { get; set; }

    }
}
