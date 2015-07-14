using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Personel : EntityBase<Guid>
    {
        public string FirstName { get; set; } // CharLength:50
        public string LastName { get; set; } // CharLength:50
        // delete field, replaced by textual position - public int PositionId { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
        public int ClientStationId { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public string PhoneNumber { get; set; } // CharLength:50
        public bool MobileEnabled { get; set; } // nullable:NO
        public string MobilePass { get; set; } // CharLength:50
        public string VehicleNumber { get; set; } // CharLength:200
        public string Email { get; set; } // CharLength:200
        public string EmployeeNumber { get; set; } // CharLength:20
        public string PrivatePhoneNo { get; set; } // CharLength:200
        public string PersonalAddress { get; set; } // CharLength:500
        public string DefaultLang { get; set; } // nullable:NO// CharLength:2
        public string Position { get; set; } // CharLength:100
        public string IceContact { get; set; } // CharLength:300
        public Vehicle Vehicle { get; set; } 
    }
}
