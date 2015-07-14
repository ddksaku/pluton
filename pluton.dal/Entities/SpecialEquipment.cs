using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class SpecialEquipment : EntityBase<Guid>
    {
        public string SpecialEquipmentName { get; set; } // CharLength:100
        public bool Active { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
    }
}
