using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Culture;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Culture;
using Centroware.Model.ViewModels.Culture;
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
    public class CultureService : ICultureService
    {

        private readonly IBaseRepository<Culture> _cultureRepository;
        private readonly IBaseRepository<CultureItem> _cultureItemRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CultureService(IBaseRepository<Culture> cultureRepository, IBaseRepository<CultureItem> cultureItemRepository, IMapper mapper, IFileService fileService)
        {
            _cultureRepository = cultureRepository;
            _cultureItemRepository = cultureItemRepository;
            _mapper = mapper;
            _fileService = fileService;

        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _cultureRepository.Filter(filter: x =>
            string.IsNullOrEmpty(query.GeneralSearch) || x.Titel.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new CultureVm
            {
                Id = x.Id,
                MainImage = x.MainImage,
                TitelLink = x.TitelLink,
                Titel = x.Titel,

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

        public async Task<CultureUpdateDto> Get(int id)
        {
            var data = await _cultureRepository.Get(id);
            if (data != null)
            {
                var dataVm = _mapper.Map<CultureUpdateDto>(data);
                return dataVm;
            }
            return null;
        }

        public async Task<CultureItem> AddCultureItem(CultureItemCreateDto input)
        {
            if (input == null)
                return null;
            var cultureItem = _mapper.Map<CultureItemCreateDto, CultureItem>(input);
            if (input.ImageItemFile != null)
            {
                cultureItem.ImageItem = await _fileService.SaveFile(input.ImageItemFile, "Images");
            }
            await _cultureItemRepository.AddAsync(cultureItem);
            return cultureItem;
        }
        public async Task<bool> AddCulture(CultureCreateDto input)
        {


            var culture = _mapper.Map<CultureCreateDto, Culture>(input);
            culture.MainImage = await _fileService.SaveFile(input.MainImageFile, "Images");
            await _cultureRepository.AddAsync(culture);
            var cultureItem = await _cultureItemRepository.Find(x => x.CultureStringId == input.CultureStringId);
            if (cultureItem != null && cultureItem.Any())
            {
                foreach (var item in cultureItem)
                {
                    item.CultureId = culture.Id;
                }
                await _cultureItemRepository.UpdateRangeAsync(cultureItem);
            }
            return true;

        }
        public async Task<List<CultureItem>> GetAllCultureItem(int id)
        {
            return await _cultureItemRepository.Find(x => x.CultureId == id);
        }

        public async Task<bool> RemoveCultureItem(int id)
        {
            var cultureItem = await _cultureItemRepository.Get(id);
            if (cultureItem == null)
                return false;
            await _cultureItemRepository.DeleteAsync(cultureItem);
            return true;
        }


        public async Task<bool> UpdateCulture(CultureUpdateDto input)
        {
            var culture = await _cultureRepository.Get(input.Id);
            culture.Titel = input.Titel;
            culture.TitelLink = input.TitelLink;
            culture.Description = input.Description;

            if (input.MainImageFile != null)
            {
                culture.MainImage = await _fileService.SaveFile(input.MainImageFile, "Images");
            }

            await _cultureRepository.UpdateAsync(culture);
            return true;
        }


        public async Task<bool> Delete(int id)
        {
            if (id > 0)
            {
                var team = await _cultureRepository.Get(id);
                await _cultureRepository.DeleteAsync(team);
                return true;
            }
            return false;
        }

    }
}
