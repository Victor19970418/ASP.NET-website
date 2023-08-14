using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class AnswerLike
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string CourseId { get; set; }
        public string MemberId { get; set; }
    }
}
