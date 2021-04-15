using Centroware.Model.Entities.enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.OurFrinds
{
    public class OurFriendsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Image { get; set; }
        public CategoryFriends CategoryFriends { get; set; }
    }
}
