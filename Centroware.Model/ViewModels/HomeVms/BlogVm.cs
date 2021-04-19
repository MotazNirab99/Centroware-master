using Centroware.Model.ViewModels.Blog;
using Centroware.Model.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
    public class BlogVm
    {
        public List<PostsVm> Jobs { get; set; }
        public AboutSettingVm About { get; set; }
    }
}
