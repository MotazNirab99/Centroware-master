

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.DTOs.Services
{
   public  class ServiceCreateDto
    {
        public string Title { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
    }
}
