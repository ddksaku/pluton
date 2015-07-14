using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class TaskSortType: EntityBase<Guid>
    {
        public string TaskSortTypeDescription { get; set; } // CharLength:200
        public DateTime DateCreated { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
        public bool AllowMassDelete { get; set; } // nullable:NO
    }
}
