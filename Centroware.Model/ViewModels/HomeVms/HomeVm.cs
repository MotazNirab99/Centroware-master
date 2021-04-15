using Centroware.Model.ViewModels.AwardsVm;
using Centroware.Model.ViewModels.OurFrinds;
using Centroware.Model.ViewModels.Sayings;
using Centroware.Model.ViewModels.Settings;
using Centroware.Model.ViewModels.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
    public class HomeVm
    {
        public HomeSettingVm HomeSetting { get; set; }
        public List<OpinoinVm> OpinoinVm { get; set; }
        public List<WorkVm> Worsk { get; set; }
        public List<OurFriendsVm> OurFriends { get; set; }
        public SumAwards Awards { get; set; }
    }
}
