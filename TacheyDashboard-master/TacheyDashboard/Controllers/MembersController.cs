using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Interface;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
//Uncaught TypeError: Cannot read property 'length' of null
namespace TacheyDashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MembersController : Controller
    {
        private readonly MemberInterface _memberService;

        public MembersController(MemberInterface memberService)
        {
            _memberService = memberService;
            
        }

        public IActionResult Member()
        {
            var result = _memberService.GetAllMemberData();
            string jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = jsonString;
            return View();
        }
        [HttpPost]
        public dynamic OrderData()
        {
            var result = _memberService.GetAllMemberData();
            string jsonString = JsonConvert.SerializeObject(result);
            return jsonString;
        }
    }
}
