using Centroware.Model.Constants;
using Centroware.Model.DTOs.Blog;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.Entities.Identity;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centroware.Web.Areas.Panel.Controllers.Blog
{
    public class BlogController : BaseController
    {
        private readonly IPostsService _postsService;
        public BlogController(IPostsService postsService, UserManager<CentrowareUser> userManager) : base(userManager)
        {
            _postsService = postsService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _postsService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(PostsCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _postsService.AddPosts(input);
                if (isCreated) return Content(Constant.AddSuccessResult());
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _postsService.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostsUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _postsService.UpdatePosts(input);
                if (isUpdated) return Content(Constant.EditSuccessResult());
            }
            return View(input);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _postsService.Delete(id);
            if (isDeleted) return Content(Constant.DeleteSuccessResult());
            return Content(Constant.DeleteFailedResult());
        }
    }
}
