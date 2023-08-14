using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Invoice
    {
        public string OrderId { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceEmail { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceNum { get; set; }
        public int? InvoiceRandomNum { get; set; }
    }
}
