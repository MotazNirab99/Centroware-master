using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Culture;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Culture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface  ICultureService 
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<CultureUpdateDto> Get(int id);
        Task<bool> AddCulture(CultureCreateDto input);
        Task<bool> UpdateCulture(CultureUpdateDto input);
        Task<bool> Delete(int id);
        Task<List<CultureItem>> GetAllCultureItem(int id);
        Task<CultureItem> AddCultureItem(CultureItemCreateDto input);
        Task<bool> RemoveCultureItem(int id);
    }
}
