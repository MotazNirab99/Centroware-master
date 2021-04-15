using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.OurFrinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IOurFriendsService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<OurFriendsUpdateDto> Get(int id);
        Task<bool> AddOurFriends(OurFriendsCreateDto input);
        Task<bool> UpdateOurFriends(OurFriendsUpdateDto input);
        Task<bool> Delete(int id);
    }
}
