using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class OrgUnitType : EntityBase<Guid>
    {
        public string OperatingUnitDescription { get; set; } // CharLength:100
        public int HierachyOrder { get; set; }
        public OrgUnitType Parent { get; set; }
        public DateTime DateCreated { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
    }
}
