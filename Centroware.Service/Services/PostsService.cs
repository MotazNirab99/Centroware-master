using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Blog;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Blog;
using Centroware.Model.ViewModels.Blog;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class PostsService : IPostsService
    {
     
            private readonly IBaseRepository<Posts> _postsRepository;
            private readonly IMapper _mapper;
            private readonly IFileService _fileService;

            public PostsService(IBaseRepository<Posts> postsRepository, IMapper mapper, IFileService fileService)
            {
                 _postsRepository = postsRepository;
                _mapper = mapper;
                _fileService = fileService;
            }

            public async Task<bool> AddPosts(PostsCreateDto input)
            {
                var posts = _mapper.Map<PostsCreateDto, Posts>(input);
                if (input.ImageFile != null)
                {
                posts.Image = await _fileService.SaveFile(input.ImageFile, "Images");
                }
                
                await _postsRepository.AddAsync(posts);
                return true;

            }

            public async Task<PostsUpdateDto> Get(int id)
            {
                var data = await _postsRepository.Get(id);
                if (data != null)
                {
                    var dataVm = _mapper.Map<PostsUpdateDto>(data);
                    return dataVm;
                }
                return null;
            }

            public async Task<bool> Delete(int id)
            {
                var opinoin = await _postsRepository.Get(id);
                if (opinoin == null)
                    return false;
                await _postsRepository.DeleteAsync(opinoin);
                return true;
            }

            public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
            {
                var skipValue = (pagination.Page - 1) * pagination.PerPage;
                var data = _postsRepository.Filter(filter: x =>
               string.IsNullOrEmpty(query.GeneralSearch) || x.Title.Contains(query.GeneralSearch),
                orderBy: x => x.OrderByDescending(x => x.Id));
                var dataCount = await data.CountAsync();
                if (skipValue >= dataCount)
                {
                    skipValue = 0;
                    pagination.Page = 1;
                }
                var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
                var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new PostsVm
                {
                    Id = x.Id,
                    Image = x.Image,
                   Title = x.Title,
                   Description = x.Description,
                   CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),

                }).ToListAsync();
                var response = new ResponseDto
                {
                    meta = new Meta
                    {
                        page = pagination.Page,
                        perpage = pagination.PerPage,
                        total = dataCount,
                        pages = pages,
                    },
                    data = dataList

                };
                return response;

            }

        public async Task<bool> UpdatePosts(PostsUpdateDto input)
        {
            var posts = await _postsRepository.Get(input.Id);
            posts.Title = input.Title;
            posts.Description = input.Description;
            if (input.ImageFile != null)
            {
                posts.Image = await _fileService.SaveFile(input.ImageFile, "Images");
            }

            await _postsRepository.UpdateAsync(posts);
            return true;
        }
    }
}
