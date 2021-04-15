using Centroware.Model.Constants;
using Centroware.Model.DTOs.AwardsDto;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Awards
{
      public class AwardsController : BaseController
    {
        private readonly IAwardsService _awardsService;
        public AwardsController(IAwardsService awardsService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _awardsService = awardsService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _awardsService.GetAll(pagination, query);
            return Json(response);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AwardsCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _awardsService.AddAwards(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _awardsService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AwardsUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _awardsService.UpdateAwards(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _awardsService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
