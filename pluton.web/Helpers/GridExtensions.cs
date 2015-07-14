using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using pluton.web.Infrastructure.Attributes.ModelAttributes;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Helpers
{
    public static class GridExtensions
    {
        private static TagBuilder BuildRow<T>(T item, IEnumerable<PropertyInfo> props)
        {
            var sb = new StringBuilder();
            var row = new TagBuilder("tr");
            foreach (var propertyInfo in props)
            {
                var value = propertyInfo.GetValue(item);
                sb.Append(new TagBuilder("td") { InnerHtml = value == null ? string.Empty : value.ToString() });
            }
            row.InnerHtml = sb.ToString();
            return row;
        }

        /// <summary>
        /// Create table in populate it with data. Table columns will be added acording to GridOrder attributes in item model.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="listModel"></param>
        /// <param name="controllerName"></param>
        /// <param name="opts"></param>
        /// <returns></returns>
        public static MvcHtmlString Table(this HtmlHelper helper, ListModel listModel, string controllerName, GridOptions opts)
        {
            if (!listModel.List.Any())
            {
                return MvcHtmlString.Empty;
            }

            PropertyInfo[] props = listModel.List.First().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-hover");

            var thead = new TagBuilder("thead");
            var headers = new StringBuilder();

            var propsInGrid = props.Where(x => x.GetCustomAttribute<GridOrderAttribute>() != null);
            var orderedProps =
                propsInGrid.OrderBy(
                    x => x.GetCustomAttribute<GridOrderAttribute>().Order);

            foreach (var propertyInfo in orderedProps)
            {
                var innerLink = new TagBuilder("span");

                var sortPropertyAttribute = propertyInfo.GetCustomAttribute<GridSortPropNameAttribute>();
                var sortProp = sortPropertyAttribute != null ? sortPropertyAttribute.SortPropnName : propertyInfo.Name;
                //NOTE: Move 'grid' to contants.
                innerLink.MergeAttribute("data-asc-link", urlHelper.Action("Grid", controllerName, new { Asc = true, SortBy = sortProp }));
                innerLink.MergeAttribute("data-desc-link", urlHelper.Action("Grid", controllerName, new { Asc = false, SortBy = sortProp }));
                innerLink.MergeAttribute("data-asc", (!listModel.Sort.Asc).ToString());

                var displayName = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
                innerLink.InnerHtml = displayName != null ? displayName.DisplayName : propertyInfo.Name;

                innerLink.AddCssClass("sort-anchor");
                headers.Append(new TagBuilder("th") { InnerHtml = innerLink.ToString() });
            }

            thead.InnerHtml = (new TagBuilder("tr") { InnerHtml = headers.ToString() }).ToString();

            var rows = new StringBuilder();
            foreach (var dataitem in listModel.List)
            {
                var row = BuildRow(dataitem, orderedProps.ToArray());
                if (opts.EnableEntryLink)
                {
                    row.MergeAttribute("data-index-url",
                                       urlHelper.Action("Index", controllerName, new { id = dataitem.Id }));
                }
                rows.Append(MvcHtmlString.Create(row.ToString()));
            }
            table.InnerHtml = string.Join(string.Empty, thead, rows.ToString());
            return MvcHtmlString.Create(table.ToString());
        }

        /// <summary>
        /// Create grid with paging. Just use this extension in View.If we want to support Url sharing, we should add PagingOptions param here.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static MvcHtmlString Grid(this HtmlHelper helper, string controllerName)
        {
            var tableContainer = new TagBuilder("div");
            tableContainer.AddCssClass("tableContainer");

            //NOTE: Move 'grid' to contants.
            tableContainer.InnerHtml = helper.Action("Grid", controllerName, new PagingOptions()).ToString(); ;
            return MvcHtmlString.Create(tableContainer.ToString());
        }
    }
}