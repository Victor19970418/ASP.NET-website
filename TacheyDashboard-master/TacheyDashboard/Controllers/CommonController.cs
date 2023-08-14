using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Controllers
{
    [Authorize]
    public class CommonController : Controller
    {
        public CommonController()
        {
        }
        public IActionResult UploadVideo()
        {
            return View();
        }


    }
}
