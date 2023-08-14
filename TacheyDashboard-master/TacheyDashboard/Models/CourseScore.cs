using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class CourseScore
    {
        public string CourseId { get; set; }
        public string MemberId { get; set; }
        public int? Score { get; set; }
        public string Title { get; set; }
        public string ScoreContent { get; set; }
        public string ToTeacher { get; set; }
        public string ToTachey { get; set; }
        public DateTime? ScoreDate { get; set; }
    }
}
