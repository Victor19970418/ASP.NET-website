using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Point
    {
        public int PointId { get; set; }
        public string MemberId { get; set; }
        public string PointName { get; set; }
        public int PointNum { get; set; }
        public int ValidDate { get; set; }
        public bool Status { get; set; }
        public string GetTime { get; set; }
        public string Deadline { get; set; }
    }
}
