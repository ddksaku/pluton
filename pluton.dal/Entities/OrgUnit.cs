using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class OrgUnit:EntityBase<Guid>
    {
        public OrgUnitType OrgUnitType { get; set; } // nullable:NO
        public OrgUnit Parent { get; set; } // nullable:NO
        public string UnitDescription { get; set; } // nullable:NO// CharLength:100
        public string UnitCity { get; set; } // CharLength:100
        public string UnitAddress { get; set; } // CharLength:100
        public string UnitPostalCode { get; set; } // CharLength:100
        public string UnitTelephoneNo { get; set; } // CharLength:100
        public string UnitKeyContactPerson { get; set; } // CharLength:100
        public bool Active { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public DateTime LastUpdated { get; set; } // nullable:NO
    }
}
