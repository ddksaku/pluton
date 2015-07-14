using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class User:EntityBase<Guid>
    {
        public UserRole Role { get; set; } // nullable:NO
        public Country Country { get; set; } // nullable:NO
        public string UserName { get; set; } // nullable:NO// CharLength:50
        public string Password { get; set; } // nullable:NO// CharLength:300
        public string FirstName { get; set; } // nullable:NO// CharLength:50
        public string LastName { get; set; } // nullable:NO// CharLength:50
        public string EmailAddress { get; set; } // nullable:NO// CharLength:80
        public string PhoneNumber { get; set; } // CharLength:30
        // delete field - public int SearchDefaultId { get; set; } // nullable:NO
        public DateTime LastActive { get; set; }
        public int FailedLoginAttempts { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
        public DateTime DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; } // nullable:NO
        // delete field - public int OrganizationId { get; set; } 
        public int ClientStationId { get; set; }
        public string DefaultLanguage { get; set; } // CharLength:2
    }
}
