using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StateManageProject.Models;

namespace StateManageProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        [TempData]
        public string sss { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            sss = "tempdata";
            HttpContext.Session.Set("Session-Name", Encoding.ASCII.GetBytes("kamal"));
            return View();
        }

        public IActionResult Privacy()
        {
            byte[] sess ;            
            HttpContext.Session.TryGetValue("Session-Name", out sess);
            ViewBag.SessionValueExtension = SessionExtensions.GetString(HttpContext.Session, "Session-Name");
            ViewBag.SessionValue = Encoding.UTF8.GetString(sess) ;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
