namespace pluton.web.Helpers
{
    public class GridOptions
    {
        public GridOptions()
            : this(true)
        {
        }

        public GridOptions(bool enableEntryLink)
        {
            EnableEntryLink = enableEntryLink;
        }

        public bool EnableEntryLink { get; set; }
    }
}