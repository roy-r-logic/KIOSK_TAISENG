using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SSKWeb.Helpers;
using SSKWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController()
        //{
        //    var session = AppSession.GetInstance();
        //    var vm = new MainLayoutViewModel()
        //    {
        //        isDirectToHome = session.isDirectToHome
        //    };
            

        //    ViewData["MainLayoutViewModel"] = vm.isDirectToHome;
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = AppSession.GetInstance();
            //var vm = new MainLayoutViewModel()
            //{
            //    isDirectToHome = session.isDirectToHome
            //};


            //ViewData["MainLayoutViewModel"] = vm.isDirectToHome;
          //  ViewBag.isDirectToHome = vm.isDirectToHome;
        }
        public async Task<IActionResult> Index()
        {
            AppSession.Dispose();

            await Task.CompletedTask;
            return View();
        }

        [HttpGet(nameof(IsSessionDisposed))]
        public async Task<IActionResult> IsSessionDisposed()
        {
            await Task.CompletedTask;
            return Ok(AppSession.HasData());
        }

    }
}
