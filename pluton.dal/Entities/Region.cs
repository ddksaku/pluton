using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Region : EntityBase<Guid>
    {
        public string RegionName { get; set; } // CharLength:100
        public bool Active { get; set; }
        public int ClientStationId { get; set; }
        public User CreatedBy { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
    }
}
