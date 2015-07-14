using System;
using System.ComponentModel;
using pluton.web.Infrastructure.Attributes.ModelAttributes;
using pluton.web.Models.Common.Grid;

namespace pluton.web.Models
{
    public class UserRequestItemModel : IGridItem
    {
        [GridOrder(0)]
        [DisplayName("[%Name%]")]
        public string FirstName { get; set; }

        [GridOrder(1)]
        [DisplayName("[%Last name%]")]
        public string LastName { get; set; }

        [GridOrder(2)]
        [DisplayName("[%Email%]")]
        public string EmailAddress { get; set; }

        [GridOrder(3)]
        [DisplayName("[%Phone%]")]
        public string PhoneNumber { get; set; }

        [GridOrder(4)]
        [DisplayName("[%User's Id%]")]
        [GridSortPropNameAttribute("User.Id")]
        public Guid? UserId { get; set; }

        [GridOrder(5)]
        [DisplayName("[%Rejected%]")]
        public bool Rejected { get; set; }

        [GridOrder(6)]
        [DisplayName("[%Complete date%]")]
        public DateTime CompleteDate { get; set; }

        public Guid Id { get; set; }
    }
}