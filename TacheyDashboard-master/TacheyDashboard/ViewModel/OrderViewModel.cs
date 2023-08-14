using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.ViewModel
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PayMethod { get; set; }
        public decimal? TotalPrice { get; set; }

    }
}
