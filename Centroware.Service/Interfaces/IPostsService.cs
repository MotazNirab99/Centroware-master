using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blog;
using Centroware.Model.DTOs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IPostsService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<PostsUpdateDto> Get(int id);
        Task<bool> AddPosts(PostsCreateDto input);
        Task<bool> UpdatePosts(PostsUpdateDto input);
        Task<bool> Delete(int id);
    }
}
