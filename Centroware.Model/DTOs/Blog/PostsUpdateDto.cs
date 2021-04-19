using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Blog
{
    public class PostsUpdateDto : PostsCreateDto
    {
        public int Id { get; set; }
    }
}
