using System;

namespace pluton.web.Infrastructure.Attributes.ModelAttributes
{
    /// <summary>
    /// Grid order
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class GridOrderAttribute : Attribute
    {
        public int Order { get; set; }

        public GridOrderAttribute(int order)
        {
            Order = order;
        }
    }
}