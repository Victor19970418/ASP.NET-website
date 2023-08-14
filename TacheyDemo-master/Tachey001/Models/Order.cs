namespace Tachey001.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public string OrderID { get; set; }

        [StringLength(128)]
        public string UsePoint { get; set; }

        [StringLength(128)]
        public string TicketID { get; set; }

        [StringLength(128)]
        public string MemberID { get; set; }

        [StringLength(128)]
        public string OrderStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        [StringLength(128)]
        public string PayMethod { get; set; }

        public DateTime? PayDate { get; set; }
    }
}
