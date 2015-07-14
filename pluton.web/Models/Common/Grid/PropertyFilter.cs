using System.ComponentModel.DataAnnotations;

namespace pluton.web.Models.Common.Grid
{
    public class PropertyFilter
    {
        public string PropertyName { get; set; }

        [UIHint("DropDown")]
        public object PropertyValue { get; set; }
    }
}