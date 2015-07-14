using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Shift : EntityBase<Guid>
    {
        public string ShiftName { get; set; } // CharLength:100
        public int ShiftFrom { get; set; }
        public int ShiftTo { get; set; }
        public bool Active { get; set; } // nullable:NO
        public bool KpiExcluded { get; set; } // nullable:NO
        public bool NightShift { get; set; } // nullable:NO
        public bool NoWorkShift { get; set; } // nullable:NO
    }
}
