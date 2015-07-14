using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class UserPasswordRequest : EntityBase<Guid>
    {
        public string IpAddress { get; set; } // nullable:NO// CharLength:15
        public string FirstName { get; set; } // nullable:NO// CharLength:30
        public string LastName { get; set; } // nullable:NO// CharLength:30
        public string EmailAddress { get; set; } // nullable:NO// CharLength:60
        public bool Succedded { get; set; } // nullable:NO
        public DateTime CreateDate { get; set; } // nullable:NO
    }
}
