using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class VehicleType: EntityBase<Guid>
    {
        public string VehicleTypeDescription { get; set; } // CharLength:200
        public bool Active { get; set; } // nullable:NO
    }
}
