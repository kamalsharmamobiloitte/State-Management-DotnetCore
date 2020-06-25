using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StateManageProject.Pages
{
    public class HomeRazorModel : PageModel
    {
        [TempData]
        public string StronglyTempData { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Set("razorKey", Encoding.ASCII.GetBytes("secret"));
            TempData["usekey"] = "ka";
            StronglyTempData = "strongly tempdata";
        }
    }
}
