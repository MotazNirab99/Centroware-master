using Centroware.Model.Constants;
using Centroware.Model.DTOs.Culture;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Culture;
using Centroware.Model.Entities.Identity;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers
{
    public class CultureController : BaseController
    {
        private readonly ICultureService _cultureService;

        public CultureController(ICultureService cultureService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _cultureService = cultureService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _cultureService.GetAll(pagination, query);
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
            ViewBag.CultureStringId = Guid.NewGuid();

            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAllCultureItem(int id)
        {
            var response = await _cultureService.GetAllCultureItem(id);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CultureCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var result = await _cultureService.AddCulture(input);
                if (result)
                    return RedirectToAction("Index");
            }
            ViewBag.CultureStringId = Guid.NewGuid();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _cultureService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CultureUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var result = await _cultureService.UpdateCulture(input);
                if (result)
                    return RedirectToAction("Index");

            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _cultureService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCultureItem([FromForm] CultureItemCreateDto input)
        {
            var isCreated = await _cultureService.AddCultureItem(input);
            if (isCreated != null)
                return Ok(new
                {
                    message = Constant.AddSuccessResult(),
                    data = isCreated,
                });
            return Content(Constant.AddFuilerResult());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCultureItem(int id)
        {
            var isDeleted = await _cultureService.RemoveCultureItem(id);
            if (isDeleted)
                return Content(Constant.DeleteSuccessResult());
            return Content(Constant.AddFuilerResult());
        }
    }
}
