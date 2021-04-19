using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Blog
{
    public class PostsCreateDto
    {
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
