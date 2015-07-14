using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class MobileStatusCheck : EntityBase<Guid>
    {
        public string PhoneNumber { get; set; } // CharLength:50
        public Personel Personel { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime GpsFixTime { get; set; }
        public DateTime CreatedDate { get; set; } // nullable:NO
        public User CreatedBy { get; set; } 
    }
}
