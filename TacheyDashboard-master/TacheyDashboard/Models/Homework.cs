using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Homework
    {
        public int HwkId { get; set; }
        public string MemberId { get; set; }
        public string Hwkchapter { get; set; }
        public string Hwkname { get; set; }
        public string Hwkdescription { get; set; }
        public string HwkPhoto { get; set; }
        public int? HwkLike { get; set; }
        public string HwkUrl { get; set; }
    }
}
