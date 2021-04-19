using Centroware.Model.ViewModels.Contacts;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Centroware.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHomeService homeService) : base(homeService)
        {
        }

        public async Task<IActionResult> Index()
        {
            var response = await _homeService.GetHomePage();
            return View(response);
        }
        public async Task<IActionResult> GetServices()
        {
            var response = await _homeService.GetServices();
            return Json(response);
        }
        public async Task<IActionResult> About()
        {
            var response = await _homeService.GetAboutPage();
            return View(response);
        }
        public async Task<IActionResult> Work()
        {
            var response = await _homeService.GetWorksPage();
            return View(response);
        }
        public async Task<IActionResult> WorkDetails(int id)
        {
            var response = await _homeService.GetWork(id);
            return View(response);
        }
        public async Task<string> CreateContact(ContactVm contact)
        {
            if (ModelState.IsValid)
            {
                var response = await _homeService.CreateContact(contact);
                if (response != null)
                {
                    return "success";
                }
            }
            return "error";
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> Join()
        {
            var response = await _homeService.GetJob();
            return View(response);
        }

        public async Task<IActionResult> Blogs()
        {
            var response = await _homeService.GetBlogPage();
            return View(response);
        }


    }
}
