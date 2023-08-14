using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class CourseBuyed
    {
        public string CourseId { get; set; }
        public int OrderId { get; set; }
        public string MemberId { get; set; }
    }
}
