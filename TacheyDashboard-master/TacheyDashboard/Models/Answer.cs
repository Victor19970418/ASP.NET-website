using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string CourseId { get; set; }
        public int QuestionId { get; set; }
        public string MemberId { get; set; }
        public string AnswerContent { get; set; }
        public DateTime? AnswerDate { get; set; }
    }
}
