using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class ShiftAssignment : EntityBase<Guid>
    {
        public DateTime ShiftStartDate { get; set; } // nullable:NO
        public int ClientStationId { get; set; } // nullable:NO
        public Personel Personel { get; set; } // nullable:NO
        public Shift Shift { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
    }
}
