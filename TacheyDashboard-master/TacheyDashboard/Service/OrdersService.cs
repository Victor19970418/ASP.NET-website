using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Interface;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace TacheyDashboard.Service
{
    public class OrdersService : OrderInterface
    {

        private readonly TacheyRepository _context;
        public OrdersService(TacheyRepository context)
        {
            _context = context;
        }
        public List<OrderViewModel> GetOrderViewModels()
        {
            var order = _context.GetAll<Order>();

            var result = (from o in order
                         select new OrderViewModel
                         {
                             OrderId = o.OrderId,
                             MemberId = o.MemberId,
                             PayMethod = o.PayMethod,
                             OrderDate = o.OrderDate,
                             OrderStatus = o.OrderStatus,
                             //TotalPrice = GetTotalPrice(o.OrderId)
                         }).ToList();
            foreach (var item in result)
            {
                item.TotalPrice = GetTotalPrice(item.OrderId);
            }
            return result.ToList();
        }
        //傳OrderID進來比對資料

        public decimal GetTotalPrice(string OrderId)
        {
            var orderdetail = _context.GetAll<OrderDetail>();
            decimal result = 0;
            foreach (var item in orderdetail)
            {
                if (item.OrderId == OrderId)
                {
                    result = (decimal)(result + item.UnitPrice);
                }
            }
            return result;
        }
        /// <summary>
        /// 取得積分
        /// </summary>
        /// <returns></returns>
        public List<Point> GetPoint()
        {
            var point = _context.GetAll<Point>();

            var result = from p in point
                         select p;
        
            return result.ToList();
        }
        /// <summary>
        /// 新增積分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Point CreatePoint(Point value)
        {
            var newPoint = new Point
            {
                PointName = value.PointName,
                PointNum = value.PointNum,
                ValidDate = value.ValidDate,
                Status = false,
                //GetTime = DateTime.Now,
                //Deadline = DateTime.Now.AddDays((double)value.ValidDate)
            };

            _context.Create<Point>(newPoint);
            _context.SaveChanges();

            return newPoint;
        }
        /// <summary>
        /// 更新積分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Point UpdatePoint(Point value)
        {
            _context.Update<Point>(value);
            _context.SaveChanges();

            return value;
        }
        /// <summary>
        /// 發送積分
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Point SendPoint(int id)
        {
            var point = _context.Get<Point>(x => x.PointId == id);

            point.Status = true;
            point.GetTime = DateTime.Now.ToShortDateString();
            point.Deadline = DateTime.Now.AddDays(point.ValidDate).ToShortDateString();

            var members = _context.GetAll<Member>().Select(x=>x.MemberId);

            foreach (var item in members)
            {
                var result = new PointOwner
                {
                    MemberId = item,
                    PointId = point.PointId
                };
                _context.Create<PointOwner>(result);
            }

            _context.Update<Point>(point);
            _context.SaveChanges();

            return point;
        }
        public List<Ticket> GetTicket()
        {
            var ticket = _context.GetAll<Ticket>();

            var result = from t in ticket
                         select t;

            return result.ToList();
        }
        public void SendTicket(string ticketid)
        {
            var Member = _context.GetAll<Member>();
            foreach (var item in Member)
            {
                TicketOwner t = new TicketOwner { TicketId = ticketid, MemberId = item.MemberId };
                _context.Create<TicketOwner>(t);
               
            }
            _context.SaveChanges();

        }


    }
}