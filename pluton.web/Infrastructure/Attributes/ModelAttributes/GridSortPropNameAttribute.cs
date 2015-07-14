using System;

namespace pluton.web.Infrastructure.Attributes.ModelAttributes
{
    /// <summary>
    /// Grid sort property. Use it when sorting property is complex like a.b.c
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class GridSortPropNameAttribute : Attribute
    {
        public string SortPropnName { get; set; }

        public GridSortPropNameAttribute(string sortPropnName)
        {
            SortPropnName = sortPropnName;
        }
    }
}