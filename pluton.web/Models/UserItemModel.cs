using System;
using System.ComponentModel;
using pluton.web.Infrastructure.Attributes.ModelAttributes;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Models
{
    public class UserItemModel : IGridItem
    {
        [GridOrder(0)]
        [DisplayName("User login")]
        public string UserName { get; set; }

        [GridOrder(1)]
        [DisplayName("First and Last name")]
        [GridSortPropNameAttribute("FirstName")]
        public string Initials { get; set; }

        [GridOrder(2)]
        [GridSortPropNameAttribute("Role.RoleName")]
        public string Role { get; set; }

        [GridOrder(3)]
        [GridSortPropNameAttribute("EmailAddress")]
        public string Email { get; set; }

        [GridOrder(4)]
        [GridSortPropNameAttribute("PhoneNumber")]
        public string Phone { get; set; }

        [GridOrder(5)]
        [DisplayName("Active")]
        [GridSortPropNameAttribute("Active")]
        public bool IsActive { get; set; }

        [GridOrder(6)]
        [DisplayName("Last activity")]
        [GridSortPropNameAttribute("LastActive")]
        public DateTime LastActivity { get; set; }

        public Guid Id { get; set; }
    }
}