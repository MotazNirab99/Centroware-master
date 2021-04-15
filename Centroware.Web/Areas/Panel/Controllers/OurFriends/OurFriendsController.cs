using Centroware.Model.Constants;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.OurFrinds;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.OurFriends
{
    public class OurFriendsController : BaseController
    {
        private readonly IOurFriendsService _ourFriendsService;
        public OurFriendsController(IOurFriendsService ourFriendsService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _ourFriendsService = ourFriendsService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _ourFriendsService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(OurFriendsCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _ourFriendsService.AddOurFriends(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _ourFriendsService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OurFriendsUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _ourFriendsService.UpdateOurFriends(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _ourFriendsService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
