using Centroware.Model.ViewModels.Jobs;
using Centroware.Model.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
  public  class JoinVm
    {
        public List<JobVm> Jobs { get; set; }
        public AboutSettingVm About { get; set; }

    }
}
