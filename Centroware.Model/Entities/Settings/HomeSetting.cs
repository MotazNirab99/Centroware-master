﻿namespace Centroware.Model.Entities.Settings
{
    public class HomeSetting : BaseEntity
    {
        public string SliderImage { get; set; }
        public string SliderMobileImage { get; set; }
        public string SliderVideo { get; set; }
        public string AboutFirstTitle { get; set; }
        public string AboutSocondTitle { get; set; }
        public string AboutDescription { get; set; }
        public string OurWorkSocondTitle { get; set; }
        public string OurWorkFirstTitle { get; set; }
        public string OurWorkDescription { get; set; }
        public string AwardsTitle { get; set; }
        public string OurCustomersTitle { get; set; }
        public string OurCustomersImage { get; set; }
        public string OurFriends { get; set; }
        public string SayingFirstTitle { get; set; }
        public string SayingSoccondTitle { get; set; }
        public string TitleAwards { get; set; }
        public bool IsActiveSlider { get; set; }
        public bool IsActiveAbout { get; set; }
        public bool IsActiveService { get; set; }
        public bool IsActiveOurWork { get; set; }
        public bool IsActiveOurWorkDetails { get; set; }
        public bool IsActiveOurCustomers { get; set; }
        public bool IsActiveAwards { get; set; }
        public bool IsActiveOurFriends { get; set; }
        public bool IsActiveSaying { get; set; }
      

    }
}