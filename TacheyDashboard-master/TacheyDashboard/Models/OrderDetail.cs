using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; }
        public string CourseId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string CourseName { get; set; }
        public string BuyMethod { get; set; }
    }
}
