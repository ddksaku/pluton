using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class CertificateSkill : EntityBase<Guid>
    {
        public CertificateType CertificateType { get; set; } // nullable:NO
        public string CertificateSkillDescription { get; set; } // CharLength:200
        public bool Permament { get; set; } // nullable:NO
        public bool TimeBound { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public User CreatedBy { get; set; }
    }
}
