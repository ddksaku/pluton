using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class CertificateType : EntityBase<Guid>
    {
        public string CertificateTypeDescription { get; set; } // CharLength:100
    }
}
