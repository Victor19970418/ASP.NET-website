using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using TacheyDashboard.ViewModel.Courses;

namespace TacheyDashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly TacheyContext _context;

        private CoursesService _coursesService;

        public CoursesController(CoursesService coursesService)
        {
            _context = new TacheyContext();

            _coursesService = coursesService;
        }

        public IActionResult Product()
        {
            var result = _coursesService.GetAllCourseProduct();

            string Jsonresult = JsonConvert.SerializeObject(result);

            ViewBag.Labels = Jsonresult;

            var categoryName = _coursesService.GetAllCourseCategory();

            string Nameresult = JsonConvert.SerializeObject(categoryName);

            ViewBag.categoryName = Nameresult;

            return View();
        }

        public IActionResult Verify(bool? CreateVerify, string CourseId )
        {
            _coursesService.UpdateStepCreateVerify(CreateVerify,CourseId);

            return Redirect("Product");

        }

        public IActionResult CourseCategory()
        {
            var resultData = _coursesService.GetAllCourseCategory();

            string JsonResultData = JsonConvert.SerializeObject(resultData);

            ViewBag.Labels = JsonResultData;

            var resultDataDetail = _coursesService.GetAllCategoryDetail();

            string JsonResultDataDetail = JsonConvert.SerializeObject(resultDataDetail);

            ViewBag.LabelsDetail = JsonResultDataDetail;

            var resultId = _coursesService.GetLastCourseCategoryId();

            string JsonResultId = JsonConvert.SerializeObject(resultId);

            ViewBag.LastLabelsId = JsonResultId;

            //var resultDetailId = _coursesService.GetLastCategoryDetailId();

            //string JsonResultDetailId = JsonConvert.SerializeObject(resultDetailId);

            //ViewBag.LastLabelsDetailId = JsonResultDetailId;

            return View();
        }

        public int? CategoryDetailLastId(string id)
        {
            var resultDetailId = _coursesService.GetLastCategoryDetailId(id);

            //string JsonResultDetailId = JsonConvert.SerializeObject(resultDetailId);

            return resultDetailId;
        }

        public IActionResult AddParentChoice(int CategoryId, string CategoryName)
        {
            _coursesService.AddParentChoice(CategoryId, CategoryName);

            return Redirect("CourseCategory");
        }

        public IActionResult UpdateParentChoice(int CategoryId, string CategoryName)
        {
            _coursesService.UpdateParentChoice(CategoryId, CategoryName);

            return Redirect("CourseCategory");
        }

        public IActionResult DeleteParentChoice(int CategoryId)
        {
            _coursesService.DeleteParentChoice(CategoryId);

            return Redirect("CourseCategory");
        }

        public IActionResult AddSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            _coursesService.AddSonChoice(CategoryId, DetailID, DetailName);

            return Redirect("CourseCategory");
        }

        public IActionResult UpdateSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            _coursesService.UpdateSonChoice(CategoryId, DetailID, DetailName);

            return Redirect("CourseCategory");
        }

        public IActionResult DeleteSonChoice(int DetailID)
        {
            _coursesService.DeleteSonChoice(DetailID);

            return Redirect("CourseCategory");
        }

    }
}
