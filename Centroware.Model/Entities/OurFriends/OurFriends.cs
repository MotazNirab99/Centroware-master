using Centroware.Model.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.OurFrinds
{
    public class OurFriends : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public CategoryFriends CategoryFriends { get; set; }
    }
}
