using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class CategoryDetail
    {
        public int DetailId { get; set; }
        public int CategoryId { get; set; }
        public string DetailName { get; set; }
        public string DetailEngName { get; set; }
    }
}
