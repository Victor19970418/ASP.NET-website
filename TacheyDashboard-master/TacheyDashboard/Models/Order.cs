using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Order
    {
        public string OrderId { get; set; }
        public string UsePoint { get; set; }
        public string TicketId { get; set; }
        public string MemberId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PayMethod { get; set; }
        public DateTime? PayDate { get; set; }
    }
}
