using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.ViewModel.Home
{
    public class TotalData
    {
        public decimal OrderPrices { get; set; }
        public dynamic OrderCount { get; set; }
        public dynamic MemberNum { get; set; }
        public dynamic Categories { get; set; }
    }
}
