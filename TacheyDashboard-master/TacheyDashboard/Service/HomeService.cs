using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using Tachey001.ViewModel;
using Tachey001.ViewModel.Course;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel.Home;
using TacheyDashboard.ViewModel.Members;

namespace TacheyDashboard.Service
{
    public class HomeService
    {
        //宣告資料庫邏輯
        private TacheyRepository _tacheyRepository;
        public HomeService(TacheyRepository tacheyRepository)
        {
            _tacheyRepository = tacheyRepository;
        }

        public List<AllCourse> GetAllCourseData()
        {
            var course = _tacheyRepository.GetAll<Models.Course>();

            var result = from c in course
                         select new AllCourse
                         {
                             CourseId = c.CourseId,
                             Title = c.Title,
                             Description = c.Description,
                             TitlePageImageUrl = c.TitlePageImageUrl,
                             MarketingImageUrl = c.MarketingImageUrl,
                             Tool = c.Tool,
                             CourseLevel = c.CourseLevel,
                             Effect = c.Effect,
                             CoursePerson = c.CoursePerson,
                             OriginalPrice = c.OriginalPrice,
                             PreOrderPrice = c.PreOrderPrice,
                             TotalMinTime = c.TotalMinTime,
                             Introduction = c.Introduction,
                             MemberId = c.MemberId,
                             LecturerIdentity = c.LecturerIdentity,
                             CategoryId = c.CategoryId,
                             CategoryDetailsId = c.CategoryDetailsId,
                             CreateDate = c.CreateDate,
                             CreateFinish = c.CreateFinish,
                             CreateVerify = c.CreateVerify,
                             PreviewVideo = c.PreviewVideo,
                             CustomUrl = c.CustomUrl,
                             MainClick = c.MainClick,
                             CustomClick = c.CustomClick,
                         };


            return result.ToList();
        }

        public List<CourseCateDet> GetAllCatData()
        {
            var courseCategory = _tacheyRepository.GetAll<Models.CourseCategory>();

            var result = from c in courseCategory
                            select new CourseCateDet
                            {
                                CategoryID = c.CategoryId,
                                CategoryName = c.CategoryName,
                            };

            return result.ToList();
        }

        public List<OrderRecordSuccess> GetAllOrderData()
        {
            var orderDetail = _tacheyRepository.GetAll<OrderDetail>();
            var order = _tacheyRepository.GetAll<Order>();

            var result = from od in orderDetail
                            join o in order on od.OrderId equals o.OrderId
                            select new OrderRecordSuccess
                            {
                                OrderID = o.OrderId,
                                CourseId = od.CourseId,
                                UnitPrice = od.UnitPrice,
                                CourseName = od.CourseName,
                                BuyMethod = od.BuyMethod,
                                OrderDate = o.OrderDate,
                                PayDate = o.PayDate,
                                PayMethod = o.PayMethod
                            };

            return result.ToList();
        }

        public List<MemberViewModel> GetAllMemberData()
        {
            var member = _tacheyRepository.GetAll<Models.Member>();

            var result = from m in member
                         select new MemberViewModel
                         {
                             MemberID = m.MemberId,
                             Account = m.Account,
                             Password = m.Password,
                             Name = m.Name,
                             Email = m.Email,
                             EmailStatus = m.EmailStatus,
                             JoinTime = m.JoinTime,
                             Sex = m.Sex,
                             CountryRegion = m.CountryRegion,
                             City = m.City,
                             Address = m.Address,
                             PostalCode = m.PostalCode,
                             PhoneNumber = m.PhoneNumber,
                             Birthday = m.Birthday,
                             Interest = m.Interest,
                             Like = m.Like,
                             Expertise = m.Expertise,
                             About = m.About,
                             InterestContent = m.InterestContent,
                             Language = m.Language,
                             Photo = m.Photo,
                             Introduction = m.Introduction,
                             Theme = m.Theme,
                             Profession = m.Profession,
                             Point = m.Point,
                             Facebook = m.Facebook,
                             Line = m.Line,
                             Google = m.Google
                         };

            return result.ToList();
        }

        public dynamic GetCourseCount()
        {
            var courses = GetAllCourseData();

            var categories = GetAllCatData();


            var AnsAmount = (from c in courses
                             join ca in categories on c.CategoryId equals ca.CategoryID
                             group new { c, ca } by new { ca.CategoryName } into g
                             select new { id = g.Key.CategoryName, amount = g.Count() }).ToList();


            return AnsAmount;
        }

        public dynamic GetTotalSales()
        {
            var orders = GetAllOrderData();

            // 日期
            var now = DateTime.Now;
            now = now.Date.AddMonths(1); // 加一個月

            // 取往前12個月
            var months = Enumerable.Range(-12, 12)
                            .Select(x => new {
                                year = now.AddMonths(x).Year,
                                month = now.AddMonths(x).Month
                            });

            var changesPerYearAndMonth = months.GroupJoin(orders,
                                            m => new { month = m.month, year = m.year },
                                            revision => new {
                                                month = (revision.OrderDate ?? DateTime.MinValue).Month,
                                                year = (revision.OrderDate ?? DateTime.MinValue).Year
                                            },
                                            (p, g) => new {
                                                date = (p.month.ToString() + '/' + p.year.ToString()),
                                                count = g.Count()
                                            });

            return changesPerYearAndMonth;
        }

        public dynamic GetMonthTopFive()
        {
            var orders = GetAllOrderData();

            DateTime FirstDay = DateTime.Now.AddDays(-DateTime.Now.Day + 1); // 本月初
            DateTime LastDay = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.AddMonths(1).Day); // 本月底

            var AnsAmount = (from o in orders
                             //where o.OrderDate >= FirstDay && o.OrderDate <= LastDay
                             group o by new { o.CourseId, o.CourseName } into g
                             orderby g.Count() descending
                             select new { id = g.Key.CourseName, count = g.Count() }).Take(5).ToList();

            return AnsAmount;
        }

        public dynamic GetMembersChart()
        {
            var members = GetAllMemberData();

            var now = DateTime.Now;
            now = now.Date.AddMonths(1);

            var months = Enumerable.Range(-12, 12)
                            .Select(x => new {
                                year = now.AddMonths(x).Year,
                                month = now.AddMonths(x).Month
                            });

            var changesPerYearAndMonth = months.GroupJoin(members,
                                            m => new { month = m.month, year = m.year },
                                            revision => new {
                                                month = (revision.JoinTime ?? DateTime.MinValue).Month,
                                                year = (revision.JoinTime ?? DateTime.MinValue).Year
                                            },
                                            (p, g) => new {
                                                date = (p.month.ToString() + '/' + p.year.ToString()),
                                                count = g.Count()
                                            });

            return changesPerYearAndMonth;
        }

        public dynamic GetTotalData()
        {
            // 總銷售金額
            var orderPrices = Convert.ToDecimal(GetAllOrderData().Select(c => c.UnitPrice).Sum()); 

            // 總銷售數
            var orderCount = GetAllOrderData().Select(x => x.OrderID).Count();

            // 總會員數
            var memberNum = GetAllMemberData().Select(x => x.MemberID).Count();

            // 總開課數
            var categories = GetAllCourseData().Select(x => x.CourseId).Count();

            var totaldata = new TotalData()
                            {
                                OrderPrices = orderPrices,
                                OrderCount = orderCount,
                                MemberNum = memberNum,
                                Categories = categories
                            };

            return totaldata;
        }

    }
}
