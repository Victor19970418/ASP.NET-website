using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Ticket
    {
        public string TicketId { get; set; }
        public string TicketName { get; set; }
        public string TicketStatus { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? Ticketdate { get; set; }
        public string PayMethod { get; set; }
        public string ProductType { get; set; }
        public string UseTime { get; set; }
        public string Send { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
