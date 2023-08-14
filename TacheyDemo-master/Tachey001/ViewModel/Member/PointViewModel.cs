﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tachey001.ViewModel.Member
{
    public class PointViewModel
    {
        public string MemberID { get; set; }
        public int? Point { get; set; }
        public string PointName { get; set; }
        public int? PointNum { get; set; }
        public string GetTime { get; set; }
        public string Deadline { get; set; }
        public bool? Status { get; set; }
    }
}