using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class PersonelSkillCertification:EntityBase<Guid>
    {
        public CertificateSkill CertificateSkill { get; set; } // nullable:NO
        public Personel Personel { get; set; } // nullable:NO
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Active { get; set; } // nullable:NO
        public DateTime DateCreated { get; set; } // nullable:NO
        public User CreatedBy { get; set; } 
    }
}
