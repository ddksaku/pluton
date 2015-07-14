using System.Collections.Generic;

namespace pluton.web.Models.Common.Grid
{
    /// <summary>
    /// Grid model
    /// </summary>
    public class ListModel
    {
        public ListModel(PagingOptions paging, SortOptions sorting, GridFilter filter, IEnumerable<IGridItem> list)
        {
            Paging = paging;
            List = list;
            Sort = sorting;
            Filter = filter;
        }

        /// <summary>
        /// List of entities
        /// </summary>
        public IEnumerable<IGridItem> List { get; set; }

        /// <summary>
        /// Paging 
        /// </summary>
        public PagingOptions Paging { get; set; }

        /// <summary>
        /// Sorting
        /// </summary>
        public SortOptions Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GridFilter Filter { get; set; }
    }
}