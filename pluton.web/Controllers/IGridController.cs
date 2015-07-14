using System.Web.Mvc;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Controllers
{
    /// <summary>
    /// This means that entity controller(usual patter edit-get-delete-list) will have Grid implementation
    /// </summary>
    public interface IGridController
    {
        /// <summary>
        /// Return data for grid you want to populate.
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="sorting"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        ActionResult Grid(PagingOptions paging, SortOptions sorting, GridFilter filter);
    }
}
