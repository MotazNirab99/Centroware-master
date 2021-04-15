using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.Culture
{
    public class CultureItem : BaseEntity
    {
      
        public string ImageItem { get; set; }
        public string TitleItem { get; set; }
        public Culture Culture { get; set; }
        public int? CultureId { get; set; }
        public string CultureStringId { get; set; }


    }
}
