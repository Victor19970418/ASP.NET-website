using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class CourseUnit
    {
        public string CourseId { get; set; }
        public int? ChapterId { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string CourseUrl { get; set; }
        public string Ps { get; set; }
    }
}
