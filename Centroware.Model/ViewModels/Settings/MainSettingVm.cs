using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.ViewModels.Settings
{
    public class MainSettingVm
    {
        public int Id { get; set; }
        [Display(Name = "Logo")]
        public IFormFile Image { get; set; }
        [Display(Name = "Facebook Url")]
        public string FacebookUrl { get; set; }
        [Display(Name = "Instagram Url")]
        public string InstagramUrl { get; set; }
        [Display(Name = "LinkedIn Url")]
        public string LinkedInUrl { get; set; }
        [Display(Name = "Youtube Url")]
        public string YoutubeUrl { get; set; }
        [Display(Name = "Contact Us Title")]
        public string ContactUsTitle { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Longtude")]
        public string Longtude { get; set; }
        [Display(Name = "Latetude")]
        public string Latetude { get; set; }
    }
}
