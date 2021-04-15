using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.ViewModels.Settings
{
    public class HomeSettingVm
    {
        public int Id { get; set; }
        [Display(Name = "Main Image Slider")]
        public IFormFile Image { get; set; }
        [Display(Name = "Customers Image slider")]
        public IFormFile CustomersImage { get; set; }
        [Display(Name = "Mobile Main Image Slider")]
        public IFormFile MobileImage { get; set; }
        [Display(Name = "Video")]
        public IFormFile Video { get; set; }
        public string OurCustomersImage { get; set; }
        public string SliderMobileImage { get; set; }
        public string SliderVideo { get; set; }
        [Display(Name = "About Main Title")]
        public string AboutFirstTitle { get; set; }
        [Display(Name = "About Sub Title")]
        public string AboutSocondTitle { get; set; }
        [Display(Name = "About Description")]
        public string AboutDescription { get; set; }
        [Display(Name = "Our Work Sub Title")]
        public string OurWorkSocondTitle { get; set; }
        [Display(Name = "Our Work Main Title")]
        public string OurWorkFirstTitle { get; set; }
        [Display(Name = "Our Work Description")]
        public string OurWorkDescription { get; set; }
        [Display(Name = "Awards Title")]
        public string AwardsTitle { get; set; }
        [Display(Name = "Our Customers Title")]
        public string OurCustomersTitle { get; set; }
        [Display(Name = "Our Friends Title")]
        public string OurFriends { get; set; }
        [Display(Name = "Saying Main Title")]
        public string SayingFirstTitle { get; set; }
        [Display(Name = "Saying Sub Title")]
        public string SayingSoccondTitle { get; set; }
        public string SliderImage { get; set; }
        public string TitleAwards { get; set; }
        [Display(Name = "activate Main Slider")]
        public bool IsActiveSlider { get; set; }
        [Display(Name = "activate Culture")]
        public bool IsActiveAbout { get; set; }
        [Display(Name = "activate Service")]
        public bool IsActiveService { get; set; }
        [Display(Name = "activate Our Work")]
        public bool IsActiveOurWork { get; set; }
        [Display(Name = "activate Projects")]
        public bool IsActiveOurWorkDetails { get; set; }
        [Display(Name = "activate Customers Slider")]
        public bool IsActiveOurCustomers { get; set; }
        [Display(Name = "activate Awards")]
        public bool IsActiveAwards { get; set; }
        [Display(Name = "activate Our Friends")]
        public bool IsActiveOurFriends { get; set; }
        [Display(Name = "activate Saying")]
        public bool IsActiveSaying { get; set; }


    }

}
