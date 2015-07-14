using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Image : EntityBase<Guid>
    {
        public string Path { get; set; } // CharLength:300
        public int ReferenceId { get; set; } // nullable:NO
        public int ImageTypeId { get; set; } // nullable:NO
        public DateTime CreatedDate { get; set; } // nullable:NO
        public Personel CreatedBy { get; set; } // nullable:NO
        public double Lon { get; set; }
        public double Lat { get; set; } 
    }
}
