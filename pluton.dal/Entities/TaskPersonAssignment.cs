using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class TaskPersonAssignment:EntityBase<Guid>
    {
        public Personel Personel { get; set; } // nullable:NO
        public Task Task { get; set; } // nullable:NO
        public bool SupervisorFlag { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
    }
}
