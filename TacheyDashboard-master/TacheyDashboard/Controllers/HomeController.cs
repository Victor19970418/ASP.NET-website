using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using Tachey001.ViewModel;
using Tachey001.ViewModel.Course;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using TacheyDashboard.ViewModel.Home;
using TacheyDashboard.ViewModel.Members;

namespace TacheyDashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TacheyContext _context;
        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger, TacheyContext context, HomeService homeService)
        {
            _logger = logger;
            _context = context;
            _homeService = homeService;
        }

        public IActionResult Index20()
        {
            return View(_homeService.GetAllCourseData());
        }

        public IActionResult Index()
        {
            if (!User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UploadVideo", "Common");
            }

            var AnsAmount = _homeService.GetCourseCount();

            ViewData["TotalData"] = TotalData();

            return View(AnsAmount);
        }

        [HttpPost]
        public dynamic CourseTypesDistribution()
        {
            // 開課種類分布
            var AnsAmount = _homeService.GetCourseCount();

            return AnsAmount;
        }

        [HttpPost]
        public dynamic TotalSales()
        {
            // 總銷售金額(訂單)累計成長趨勢(走勢圖)
            var changesPerYearAndMonth = _homeService.GetTotalSales();

            return changesPerYearAndMonth;
        }

        //[HttpPost]
        //public dynamic ClickPercentage()
        //{
        // 開課種類分布(圓餅圖)、訂單銷售統計圖(長條圖)、熱門募資排行榜(長條圖)、會員數成長分布圖(走勢圖)、總銷售金額(訂單)累計成長趨勢(走勢圖)、主要點擊與客點級數(圓餅圖)
        //    // 主要點擊與客點級數
        //    var courses = from c in _context.Courses
        //                  select new AllCourse
        //                  {
        //                      MainClick = c.MainClick,
        //                      CustomClick = c.CustomClick,
        //                  };

        //    var mainClickCount = courses.Select(x => x.MainClick).Sum();

        //    var customClickCount = courses.Select(x => x.CustomClick).Sum();

        //    List<ClickView> clickCount = new List<ClickView>
        //    {
        //        new ClickView { Id = "Main", Amount = mainClickCount },
        //        new ClickView { Id = "Custom", Amount = customClickCount },
        //    };

        //    var AnsAmount = clickCount;


        //    return AnsAmount;
        //}

        [HttpPost]
        public dynamic MonthTopFive()
        {
            // 當月前5筆熱門
            var AnsAmount = _homeService.GetMonthTopFive();

            return AnsAmount;
        }

        [HttpPost]
        public dynamic MembersChart()
        {
            // 會員數成長分布圖(走勢圖)
            var changesPerYearAndMonth = _homeService.GetMembersChart();

            return changesPerYearAndMonth;
        }

        public dynamic TotalData()
        {
            var totaldata = _homeService.GetTotalData();

            return totaldata;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
