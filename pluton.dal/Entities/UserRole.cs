using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class UserRole: EntityBase<Guid>
    {
        public string ReferenceType { get; set; } // nullable:NO// CharLength:1
        public string RoleName { get; set; } // nullable:NO// CharLength:50
        // delete field - public string SearchFunction { get; set; } // nullable:NO// CharLength:50
        public int AccessFlags { get; set; } // nullable:NO
        public int RoleFlag { get; set; } // nullable:NO
        public string DefaultHomepage { get; set; } // CharLength:20
    }
}
