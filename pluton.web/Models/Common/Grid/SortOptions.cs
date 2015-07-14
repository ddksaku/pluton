namespace pluton.web.Models.Common.Grid
{
    /// <summary>
    /// Sorting data
    /// </summary>
    public class SortOptions
    {
        /// <summary>
        /// Sort prop name
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Acs or desc
        /// </summary>
        public bool Asc { get; set; }
    }
}