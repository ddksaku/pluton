using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mars.Common.UnitOfWork;
using pluton.dal.Entities;
using pluton.dal.Repository;
using pluton.web.Helpers;
using pluton.web.Models;
using pluton.web.Models.Common.Grid;
using pluton.web.Models.ModelBinders;

namespace pluton.web.Controllers
{
    public class UserRequestController : BaseController, IGridController
    {
        private readonly IQueryTranslater _queryTranslater;
        //
        // GET: /UserRequest/

        public UserRequestController(IUnitOfWork unitOfWork, IQueryTranslater qt)
            : base(unitOfWork)
        {
            _queryTranslater = qt;
        }

        [HttpGet]
        public ActionResult Grid(PagingOptions paging, SortOptions sorting, [ModelBinder(typeof(GridFilterModelBinder))]GridFilter filter)
        {
            var query = UnitOfWork.Repository<UserRequest>().Query().Include(x => x.User);

            if (!string.IsNullOrEmpty(filter.PropertyFilter.PropertyName) && filter.PropertyFilter.PropertyValue != string.Empty)
            {
                query = query.WhereFilter(x => _queryTranslater.PropertyFilter(x, filter.PropertyFilter.PropertyName, filter.PropertyFilter.PropertyValue));
            }

            int total;

            var userRequests = query.OrderBy(x => _queryTranslater.OrderByPropName(x, sorting.SortBy ?? "FirstName", sorting.Asc))
                .GetPage(paging.Page, paging.ItemsPerPage, out  total).ToList();

            paging.Total = total;
            if (string.IsNullOrEmpty(filter.PropertyFilter.PropertyName))
            {
                filter.PropertyFilter.PropertyName = "FirstName";
            }

            ViewBag.GridOptions = new GridOptions(false);
            // Temp solution. Just test purposes.
            ViewBag.PropertyValue = new List<SelectListItem>()
                {
                    new SelectListItem() {Text = "all" ,Value = ""},
                    new SelectListItem() {Text = "ccc", Value = "ccc"},
                    new SelectListItem() { Text = "nnn", Value = "nnn"}
                };

            var mappedResult = AutoMapper.Mapper.Map<IEnumerable<UserRequestItemModel>>(userRequests);


            return View(new ListModel(paging, sorting, filter, mappedResult));
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
    }
}
