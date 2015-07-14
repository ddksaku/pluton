using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Vehicle: EntityBase<Guid>
    {
        public string VehicleLicenseNo { get; set; } // CharLength:30
        public VehicleType VehicleType { get; set; }
        public bool HasLift { get; set; }
        public bool HasFlashers { get; set; }
        public string RadioNumber { get; set; } // CharLength:50
        public string Reference { get; set; } // CharLength:100
        public DateTime DateCreated { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
        public string Notes { get; set; } // CharLength:500
        public int ClientStationId { get; set; } // nullable:NO
    }
}
