using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string CourseId { get; set; }
        public string MemberId { get; set; }
        public string QuestionContent { get; set; }
        public DateTime? QuestionDate { get; set; }
    }
}
