
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.ViewModels.Settings
{
    public class AboutSettingVm
    {
        public int Id { get; set; }
        [Display(Name = "WE DO Title")]
        public string WeDoTitle { get; set; }
        [Display(Name = "WE DO Description")]
        public string WeDoDescription { get; set; }
        [Display(Name = "Our Team Main Title")]
        public string OurTeamFirstTitle { get; set; }
        [Display(Name = "Our Team Sub Title")]
        public string OurTeamSoccondTitle { get; set; }
        [Display(Name = "Our Team Description")]
        public string OurTeamDescription { get; set; }
        [Display(Name = "Join Us Main Title")]
        public string JoinUsTitle { get; set; }
        [Display(Name = "Join Us Sub Title")]
        public string JoinUsSubTitle { get; set; }
        [Display(Name = "Join Us Image")]
        public IFormFile JoinUsImageFile { get; set; }
        public string JoinUsImage { get; set; }
        [Display(Name = "About Main Title")]
        public string AboutFirstTitel { get; set; }
        [Display(Name = "About Sub Title")]
        public string AboutSecondTitel { get; set; }
        [Display(Name = "Culture Main Title")]
        public string HeadlineCulture { get; set; }
        [Display(Name = "activate Slider")]
        public bool IsActiveSlider { get; set; }
        [Display(Name = "activate Works")]
        public bool IsActiveWorks { get; set; }
        [Display(Name = "activate Our Team")]
        public bool IsActiveOurTeam { get; set; }
        [Display(Name = "activate Culture")]
        public bool IsActiveCulture { get; set; }

    }
}
