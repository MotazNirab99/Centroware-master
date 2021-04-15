using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.Culture
{
    public class Culture : BaseEntity
    {
        public string MainImage { get; set; }
        public string Titel { get; set; }
        public string TitelLink { get; set; }
        public string Description { get; set; }

        public string CultureStringId { get; set; }
        public List<CultureItem> CultureItems { get; set; }

    }
}
