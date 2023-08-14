using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;

namespace TacheyDashboard.ViewModel.Courses
{
    public class CoursesViewModel
    {
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TitlePageImageUrl { get; set; }
        public string MarketingImageUrl { get; set; }
        public string Tool { get; set; }
        public string CourseLevel { get; set; }
        public string Effect { get; set; }
        public string CoursePerson { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? PreOrderPrice { get; set; }
        public int? TotalMinTime { get; set; }
        public string Introduction { get; set; }
        public string MemberId { get; set; }
        public string LecturerIdentity { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryDetailsId { get; set; }
        public int? DetailID { get; set; }
        public string DetailName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? CreateFinish { get; set; }
        public bool? CreateVerify { get; set; }
        public string PreviewVideo { get; set; }
        public string CustomUrl { get; set; }
        public int? MainClick { get; set; }
        public int? CustomClick { get; set; }
        public string Ps { get; set; }
        public IEnumerable<CourseChapter> courseChapters { get; set; }
        public IEnumerable<CourseUnit> courseUnits { get; set; }
    }
}
