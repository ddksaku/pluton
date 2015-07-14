using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mars.Common.UnitOfWork;
using pluton.dal.Entities;
using pluton.web.Models;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Controllers
{
    public class HomeController : BaseController, IGridController
    {
        public HomeController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public ActionResult Index()
        {
            var user = UnitOfWork.Repository<User>().Query().GetOne();
            return View();
        }

        //NOTE: Just test purposes!
        //        [HttpGet]
        //        [AllowAnonymous]
        //        public ActionResult Grid(PagingOptions paging, SortOptions sorting)
        //        {
        //            IList<TestModel> list = new List<TestModel>();
        //            for (int i = 0; i < 15; i++)
        //            {
        //                list.Add(new TestModel()
        //                    {
        //                        Description = paging.Page.ToString() + "sd" + (15 - i).ToString(),
        //                        Id = i,
        //                        Name = paging.Page.ToString() + "sad" + (15 - i).ToString()
        //                    });
        //            }
        //            paging.Total = list.Count();
        //            ViewBag.Paging = paging;
        //
        //
        //            var propInfo = typeof (TestModel).GetProperty(sorting.SortBy ?? "Name");
        //            var orderedList = sorting.Asc
        //                                  ? list.OrderByPropName(x => propInfo.GetValue(x, null))
        //                                  : list.OrderByDescending(x => propInfo.GetValue(x, null));
        //            return
        //                View(new ListModel(paging, sorting,
        //                                   orderedList.Skip((paging.Page - 1)*paging.ItemsPerPage).Take(paging.ItemsPerPage)));
        //        }


        public ActionResult Grid(PagingOptions paging, SortOptions sorting, GridFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
