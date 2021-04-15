
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.DTOs.Opinions
{
   public class OpinionDto
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        [Display(Name = "Personal Image")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
        [Display(Name = "What do you want to say")]
        public string Description { get; set; }
        public int? WorkId { get; set; }
    }
}
