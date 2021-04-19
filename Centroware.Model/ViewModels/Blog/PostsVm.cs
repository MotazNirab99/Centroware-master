﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.Blog
{
    public class PostsVm
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}