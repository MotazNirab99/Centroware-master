using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.Blog
{
    public class Blogs : BaseEntity
    {
        public string BlogTitle { get; set; }
        public string BlogsStringId { get; set; }
        public List<Posts> Posts { get; set; }
    }
}
