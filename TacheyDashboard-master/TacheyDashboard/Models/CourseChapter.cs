using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class CourseChapter
    {
        public string CourseId { get; set; }
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
    }
}
