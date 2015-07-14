using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class UserRequest:EntityBase<Guid>
    {
        public User User { get; set; }
        public Country Country { get; set; } // nullable:NO
        public string FirstName { get; set; } // nullable:NO// CharLength:50
        public string LastName { get; set; } // nullable:NO// CharLength:50
        public string EmailAddress { get; set; } // nullable:NO// CharLength:80
        public string PhoneNumber { get; set; } // nullable:NO// CharLength:30
        public int ClientStationId { get; set; } // nullable:NO
        public DateTime CreateDate { get; set; } // nullable:NO
        public bool Rejected { get; set; } // nullable:NO
        public string RejectReason { get; set; } // CharLength:1024
        public DateTime CompletedDate { get; set; }
    }
}
