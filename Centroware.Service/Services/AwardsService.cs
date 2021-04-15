using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.AwardsDto;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Awards;
using Centroware.Model.ViewModels.AwardsVm;
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
    public class AwardsService : IAwardsService
    {
        private readonly IBaseRepository<Awards> _awardsRepository;
        private readonly IMapper _mapper;

        public AwardsService(IBaseRepository<Awards> awardsRepository, IMapper mapper)
        {
            _awardsRepository = awardsRepository;
            _mapper = mapper;

        }
        public async Task<bool> AddAwards(AwardsCreateDto input)
        {

            var Awards = _mapper.Map<AwardsCreateDto, Awards>(input);
            if (input != null)
            
            await _awardsRepository.AddAsync(Awards);
            return true;

        }

        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var Awards = await _awardsRepository.Get(id);
                await _awardsRepository.DeleteAsync(Awards);
                return true;
            }
            return false;
        }
        public async Task<AwardsUpdateDto> Get(int id)
        {
            var data = await _awardsRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<AwardsUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _awardsRepository.Filter(filter: x =>
            string.IsNullOrEmpty(query.GeneralSearch) || x.Name.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new AwardsVm
            {
                Id = x.Id,
                Name = x.Name,
               Count = x.Count,
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

        public async Task<bool> UpdateAwards(AwardsUpdateDto input)
        {

            var awards = await _awardsRepository.Get(input.Id);
            awards.Name = input.Name;
            awards.Count = input.Count;


            await _awardsRepository.UpdateAsync(awards);
            return true;
        }
    
}
}
