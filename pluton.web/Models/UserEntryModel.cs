
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace pluton.web.Models
{
    public class UserEntryModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string NewPassword { get; set; }

        public IEnumerable<SelectListItem> AllRoles { get; set; }

        public bool IsActive { get; set; }

        [UIHint("DropDown")]
        public Guid DefaultRoleId { get; set; }
    }
}