using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class BreakdownReason : EntityBase<Guid>
    {
        public string BreakdownResonDescription { get; set; } // CharLength:50
        public bool Active { get; set; }
    }
}
