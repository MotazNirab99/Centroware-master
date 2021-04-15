using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.DTOs.Works
{
    public class CreateWorkDto
    {
        [Display(Name = "Image Work")]
        public IFormFile MainImageFile { get; set; }
        public string Title { get; set; }
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }
        public string About { get; set; }
        [Display(Name = "Our Part")]
        public string OurPart { get; set; }
        public int CategoryId { get; set; }
        public string WorkStringId { get; set; }
    }
}
