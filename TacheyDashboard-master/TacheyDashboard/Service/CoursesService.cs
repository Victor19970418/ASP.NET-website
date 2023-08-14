using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel.Courses;

namespace TacheyDashboard.Service
{
    public class CoursesService
    {
        //初始化資料庫邏輯
        private TacheyRepository _tacheyRepository;
        public CoursesService(TacheyRepository tacheyRepository)
        {
            _tacheyRepository = tacheyRepository;
        }
        public List<CoursesViewModel> GetAllCourseProduct()
        {
            var course = _tacheyRepository.GetAll<Course>();

            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var chapter = _tacheyRepository.GetAll<CourseChapter>();

            var unit = _tacheyRepository.GetAll<CourseUnit>();

            var result = from c in course
                         join cat in category on c.CategoryId equals cat.CategoryId
                         join det in detail on c.CategoryDetailsId equals det.DetailId
                         select new CoursesViewModel
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
                             CategoryName = cat.CategoryName,
                             DetailID = c.CategoryDetailsId,
                             DetailName = det.DetailName,
                             CreateDate = c.CreateDate,
                             CreateFinish = c.CreateFinish,
                             CreateVerify = c.CreateVerify,
                             PreviewVideo = c.PreviewVideo,
                             CustomUrl = c.CustomUrl,
                             MainClick = c.MainClick,
                             CustomClick = c.CustomClick,
                             courseChapters = chapter.Where(x => x.CourseId == c.CourseId).ToList(),
                             courseUnits = unit.Where(x => x.CourseId == c.CourseId).ToList()
                         };

            return result.ToList();
        }

        public void UpdateStepCreateVerify(bool? CreateVerify,string CourseId)
        {
            var result = _tacheyRepository.Get<Course>(x => x.CourseId == CourseId);

            result.CreateVerify = CreateVerify;

            _tacheyRepository.SaveChanges();
        }

        public List<CoursesViewModel> GetAllCourseCategory()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            //var result = from c in category
            //             join det in detail on c.CategoryId equals det.CategoryId
            //             //group c by new { c.CategoryId, c.CategoryName } into g
            //             select new CoursesViewModel
            //             {
            //                 CategoryId = c.CategoryId,
            //                 CategoryName = c.CategoryName,
            //                 DetailName = det.DetailName
            //             };

            //var result = from c in category
            //             join det in detail on c.CategoryId equals det.CategoryId

            //             group c by new { c.CategoryId, c.CategoryName } into g
            //             select new
            //             {
            //                 CategoryId = g.Key.CategoryId,
            //                 CategoryName = g.Key.CategoryName
            //             };

            //List<object> myLists = new List<object>();

            //var result = categoryResult.GroupBy(x => x.CategoryId).Select(g => myLists.Add(g.Key));

            var result = from c in category
                         select new CoursesViewModel
                         {
                             CategoryId = c.CategoryId,
                             CategoryName = c.CategoryName
                         };

            return result.ToList();
        }

        public List<CoursesViewModel> GetAllCategoryDetail()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var result = from d in detail
                         select new CoursesViewModel
                         {
                             CategoryId = d.CategoryId,
                             DetailID = d.DetailId,
                             DetailName = d.DetailName
                         };

            return result.ToList();
        }

        public List<CoursesViewModel> GetAllCategoryDetail(int CategoryId)
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var result = from d in detail
                         where d.CategoryId == CategoryId
                         select new CoursesViewModel
                         {
                             DetailName = d.DetailName
                         };

            return result.ToList();
        }

        public CoursesViewModel GetLastCourseCategoryId()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in category
                         select new CoursesViewModel
                         {
                             CategoryId = c.CategoryId,
                             CategoryName = c.CategoryName
                         };


            var result = categoryviewmodel.OrderByDescending(u => u.CategoryId).FirstOrDefault();

            return result;
        }

        public CoursesViewModel GetLastCategoryDetailId()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in detail
                                    select new CoursesViewModel
                                    {
                                        CategoryId = c.CategoryId,
                                        DetailID = c.DetailId,
                                        DetailName = c.DetailName
                                    };


            var result = categoryviewmodel.OrderByDescending(u => u.CategoryId).FirstOrDefault();

            return result;
        }

        public int GetLastCategoryDetailId(string id)
        {
            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in detail
                                    select new CoursesViewModel
                                    {
                                        CategoryId = c.CategoryId,
                                        DetailID = c.DetailId,
                                        DetailName = c.DetailName
                                    };

            var lastnum = categoryviewmodel.Where(x => x.DetailID.ToString().Substring(0, id.Length).Contains($"{id}") && x.DetailID.ToString().Length == (4 + id.Length)).OrderByDescending(x => x.DetailID).FirstOrDefault();

            var result = lastnum == null ? (id + "0001") : lastnum.DetailID.ToString();

            return int.Parse(result);
        }

        public void UpdateParentChoice(int CategoryId, string CategoryName)
        {
            var result = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId);

            result.CategoryName = CategoryName;

            _tacheyRepository.SaveChanges();
        }

        public void AddParentChoice(int CategoryId, string CategoryName)
        {
            //var result = _tacheyRepository.GetAll<CourseCategory>();
            //foreach (var item in result)
            //{
            //    CourseCategory t = new CourseCategory { CategoryId = item.CategoryId, CategoryName = item.CategoryName };
            //    _tacheyRepository.Create<CourseCategory>(t);

            //}
            //_tacheyRepository.SaveChanges();

            var ToF = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId && x.CategoryName == CategoryName);
            if (ToF == null)
            {
                var result = new CourseCategory { CategoryId = CategoryId, CategoryName = CategoryName };
                _tacheyRepository.Create(result);
            }
            else
            {
                _tacheyRepository.Delete(ToF);
            }
            _tacheyRepository.SaveChanges();


            //var result = _tacheyRepository.Get<Models.Member>(x => x.MemberID == id);

            //result.Sex = id;

            //_tacheyRepository.SaveChanges()

        }

        public void DeleteParentChoice(int CategoryId)
        {
            var result = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId);
            _tacheyRepository.Delete(result);

            var resultD = _tacheyRepository.Get<CategoryDetail>(x => x.CategoryId == CategoryId);
            _tacheyRepository.Delete(resultD);

            _tacheyRepository.SaveChanges();
        }

        public void UpdateSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            var result = _tacheyRepository.Get<CategoryDetail>(x => x.CategoryId == CategoryId && x.DetailId == DetailID);

            result.DetailName = DetailName;

            _tacheyRepository.SaveChanges();
        }

        public void AddSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            var ToF = _tacheyRepository.Get<CategoryDetail>(x => x.CategoryId == CategoryId && x.DetailId == DetailID && x.DetailName == DetailName);
            if (ToF == null)
            {
                var result = new CategoryDetail { CategoryId = CategoryId, DetailId = DetailID, DetailName = DetailName };
                _tacheyRepository.Create(result);
            }
            else
            {
                _tacheyRepository.Delete(ToF);
            }
            _tacheyRepository.SaveChanges();
        }

        public void DeleteSonChoice(int DetailID)
        {
            var result = _tacheyRepository.Get<CategoryDetail>(x => x.DetailId == DetailID);
            _tacheyRepository.Delete(result);
            _tacheyRepository.SaveChanges();

        }
    }
}
