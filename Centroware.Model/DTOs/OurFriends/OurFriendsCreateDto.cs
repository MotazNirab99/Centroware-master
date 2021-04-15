using Centroware.Model.Entities.enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.OurFrinds
{
    public class OurFriendsCreateDto
    {
        public string Name { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
        public CategoryFriends CategoryFriends { get; set; }
    }
}
