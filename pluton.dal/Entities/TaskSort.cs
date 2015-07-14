using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class TaskSort : EntityBase<Guid>
    {
        public TaskSortType TaskSortType { get; set; } // nullable:NO
        public string TaskSortDescription { get; set; } // CharLength:100
        public int UomTypeId { get; set; } // nullable:NO
        public bool Active { get; set; } // nullable:NO
        public User CreatedBy { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public string IconNumber { get; set; } // CharLength:20
        public int TaskReportingType { get; set; }
        public int TaskSortGroup { get; set; } // nullable:NO
        public string ReferenceId { get; set; } // CharLength:200
        public int TravelStdTime { get; set; } // nullable:NO
        public int StandardTimeMins { get; set; } // nullable:NO
    }
}
