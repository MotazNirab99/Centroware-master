using System.ComponentModel.DataAnnotations;

namespace Centroware.Model.Entities.Settings
{
    public class AboutSetting : BaseEntity
    {
        public string WeDoTitle { get; set; }
        public string WeDoDescription { get; set; }
        public string OurTeamFirstTitle { get; set; }
        public string OurTeamSoccondTitle { get; set; }
        public string OurTeamDescription { get; set; }
        public string JoinUsTitle { get; set; }
        public string JoinUsSubTitle { get; set; }
        public string JoinUsImage { get; set; }
        public string AboutFirstTitel { get; set; }
        public string AboutSecondTitel { get; set; }
        public string HeadlineCulture { get; set; }
        public string BlogTitel { get; set; }
        public bool IsActiveSlider { get; set; }
        public bool IsActiveWorks { get; set; }
        public bool IsActiveOurTeam { get; set; }
        public bool IsActiveCulture { get; set; }



    }
}
