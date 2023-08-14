using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Models
{
    public class TicketViewModel
    {
        public string TicketId { get; set; }
        public string TicketName { get; set; }
        public string TicketStatus { get; set; }
        public decimal? Discount { get; set; }
        public string Ticketdate { get; set; }
        public string PayMethod { get; set; }
        public string ProductType { get; set; }
        public string UseTime { get; set; }
        public string Send { get; set; }
        public string SendDate { get; set; }
    }
}
