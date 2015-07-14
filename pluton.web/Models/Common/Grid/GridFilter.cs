namespace pluton.web.Models.Common.Grid
{
    public class GridFilter
    {
        public GridFilter()
        {
            AlphaFilter = new AlphabeticFilter();
            PropertyFilter = new PropertyFilter();
        }

        public AlphabeticFilter AlphaFilter { get; set; }

        public PropertyFilter PropertyFilter { get; set; }
    }
}