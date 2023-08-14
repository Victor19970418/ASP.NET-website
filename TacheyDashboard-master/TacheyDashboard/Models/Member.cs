using System;
using System.Collections.Generic;

#nullable disable

namespace TacheyDashboard.Models
{
    public partial class Member
    {
        public string MemberId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? EmailStatus { get; set; }
        public DateTime? JoinTime { get; set; }
        public string Sex { get; set; }
        public string CountryRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Interest { get; set; }
        public string Like { get; set; }
        public string Expertise { get; set; }
        public string About { get; set; }
        public string InterestContent { get; set; }
        public string Language { get; set; }
        public string Photo { get; set; }
        public string Introduction { get; set; }
        public string Theme { get; set; }
        public string Profession { get; set; }
        public int? Point { get; set; }
        public string Facebook { get; set; }
        public string Line { get; set; }
        public string Google { get; set; }
    }
}
