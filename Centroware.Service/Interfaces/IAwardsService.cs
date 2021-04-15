using Centroware.Model.DTOs;
using Centroware.Model.DTOs.AwardsDto;
using Centroware.Model.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IAwardsService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<AwardsUpdateDto> Get(int id);
        Task<bool> AddAwards(AwardsCreateDto input);
        Task<bool> UpdateAwards(AwardsUpdateDto input);
        Task<bool> Delete(int id);
    }
}
