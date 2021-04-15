using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.Culture
{
    public class CultureVm
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string MainImage { get; set; }
        public string Titel { get; set; }
        public string TitelLink { get; set; }
        public string Description { get; set; }

        public List<CultureItemVm> CultureItems { get; set; }

    }
}
