using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class UserOrgSelection : EntityBase<Guid>
    {
        public OrgUnit OrgUnit { get; set; } // nullable:NO
        public User User { get; set; } // nullable:NO
    }
}
