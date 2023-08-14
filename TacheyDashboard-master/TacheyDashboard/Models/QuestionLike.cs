using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class QuestionLike
    {
        public int QuestionId { get; set; }
        public string CourseId { get; set; }
        public string MemberId { get; set; }
    }
}
