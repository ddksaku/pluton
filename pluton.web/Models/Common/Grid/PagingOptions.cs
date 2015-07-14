namespace pluton.web.Models.Common.Grid
{
    /// <summary>
    /// Paging data
    /// </summary>
    public class PagingOptions
    {
        private const int DefaultPerPage = 10;
        private const int DefaultPage = 1;

        public PagingOptions() : this(0, DefaultPerPage, DefaultPage)
        {
        }

        public PagingOptions(int total, int perPage, int page)
        {
            Total = total;
            ItemsPerPage = perPage;
            Page = page;
        }

        /// <summary>
        /// Total item count
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Items per page
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }
    }
}