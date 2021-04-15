using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.OurFrinds;
using Centroware.Model.Entities.OurFrinds;
using Centroware.Model.ViewModels.OurFrinds;
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
    public class OurFriendsService : IOurFriendsService
    {
        private readonly IBaseRepository<OurFriends> _ourFrindsRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public OurFriendsService(IBaseRepository<OurFriends> ourFrindsRepository, IMapper mapper, IFileService fileService)
        {
            _ourFrindsRepository = ourFrindsRepository;
            _mapper = mapper;
            _fileService = fileService;

        }
        public async Task<bool> AddOurFriends(OurFriendsCreateDto input)
        {
           
            var OurFriend = _mapper.Map<OurFriendsCreateDto, OurFriends>(input);
            if (input.ImageFile != null)
            {
                OurFriend.Image = await _fileService.SaveFile(input.ImageFile, "Images");
            }
            await _ourFrindsRepository.AddAsync(OurFriend);
                return true;
            
        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var OurFrinds = await _ourFrindsRepository.Get(id);
                await _ourFrindsRepository.DeleteAsync(OurFrinds);
                return true;
            }
            return false;
        }
        public async Task<OurFriendsUpdateDto> Get(int id)
        {
            var data = await _ourFrindsRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<OurFriendsUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _ourFrindsRepository.Filter(filter: x =>
            string.IsNullOrEmpty(query.GeneralSearch) || x.Name.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new OurFriendsVm
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                CategoryFriends = x.CategoryFriends
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

        public async Task<bool> UpdateOurFriends(OurFriendsUpdateDto input)
        {

            var ourFriends = await _ourFrindsRepository.Get(input.Id);
            ourFriends.Name = input.Name;
            ourFriends.CategoryFriends = input.CategoryFriends;
            if (input.ImageFile != null)
            {
                ourFriends.Image = await _fileService.SaveFile(input.ImageFile, "Images");
            }
           
            await _ourFrindsRepository.UpdateAsync(ourFriends);
            return true;
        }
    }
}
