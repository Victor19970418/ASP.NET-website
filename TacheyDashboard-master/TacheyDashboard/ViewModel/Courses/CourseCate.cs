using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.ViewModel.Courses
{
    public class CourseCate
    {
        public string CourseId { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int? CategoryDetailsId { get; set; }
        public int? DetailID { get; set; }
        public string CategoryName { get; set; }
        public string DetailName { get; set; }
    }
}
