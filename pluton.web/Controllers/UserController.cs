using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mars.Common.UnitOfWork;
using pluton.dal.Entities;
using pluton.dal.Repository;
using pluton.web.Models;
using pluton.web.Models.Common.Grid;
using pluton.web.Models.ModelBinders;

namespace pluton.web.Controllers
{
    public class UserController : BaseController, IGridController
    {
        private readonly IQueryTranslater _queryTranslater;

        public UserController(IUnitOfWork unitOfWork, IQueryTranslater qt)
            : base(unitOfWork)
        {
            _queryTranslater = qt;
        }

        public ActionResult Grid(PagingOptions paging, SortOptions sorting, [ModelBinder(typeof(GridFilterModelBinder))]GridFilter filter)
        {
            var query = UnitOfWork.Repository<User>().Query().Include(x => x.Role);
            if (!string.IsNullOrEmpty(filter.AlphaFilter.AlphaPropName) && !string.IsNullOrEmpty(filter.AlphaFilter.BeginFrom))
            {
                query = query.WhereFilter(x => _queryTranslater.AlphaFilter(x, filter.AlphaFilter.AlphaPropName, filter.AlphaFilter.BeginFrom));
            }

            int total = 0;

            var users = query.OrderBy(x => _queryTranslater.OrderByPropName(x, sorting.SortBy ?? "UserName", sorting.Asc))
                .GetPage(paging.Page, paging.ItemsPerPage, out  total).ToList();

            paging.Total = total;
            if (string.IsNullOrEmpty(filter.AlphaFilter.AlphaPropName))
            {
                filter.AlphaFilter.AlphaPropName = "UserName";
            }

            var mappedResult = AutoMapper.Mapper.Map<IEnumerable<UserItemModel>>(users);
            return View(new ListModel(paging, sorting, filter, mappedResult));
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(Guid id)
        {
            var user = UnitOfWork.Repository<User>().Query().Filter(x => x.Id == id).GetOne();
            var model = AutoMapper.Mapper.Map<UserEntryModel>(user);
            model.AllRoles =
                UnitOfWork.Repository<UserRole>()
                          .Query()
                          .Get().ToList()
                          .Select(
                              x =>
                              new SelectListItem() { Selected = x.Id == user.Role.Id, Text = x.RoleName, Value = x.Id.ToString() });

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserEntryModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var user = UnitOfWork.Repository<User>().Query().Filter(x => x.Id == model.Id).GetOne();
            if (user == null)
            {
                return HttpNotFound();
            }
            user = AutoMapper.Mapper.Map(model, user);
            if (user.Role.Id != model.DefaultRoleId)
            {
                var newRole =
                    UnitOfWork.Repository<UserRole>().Query().Filter(x => x.Id == model.DefaultRoleId).GetOne();
                if (newRole == null)
                {
                    return HttpNotFound();
                }
                user.Role = newRole;
            }
            UnitOfWork.Repository<User>().Update(user);
            UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
