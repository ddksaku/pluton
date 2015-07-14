using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class MobileDataSubmission : EntityBase<Guid>
    {
        public Task Task { get; set; } // nullable:NO
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string OperatorNotes { get; set; } // CharLength:1000
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string PhoneNumber { get; set; } // CharLength:50
        public Personel Personel { get; set; }
        public DateTime SubmissionTime { get; set; } // nullable:NO
        public int StartSwitch { get; set; } // nullable:NO
        public int EndSwitch { get; set; } // nullable:NO
        public string VehicleLicenseNo { get; set; } // CharLength:50
        public bool TaskRealized { get; set; }
        public DateTime GpsFixTime { get; set; } 
    }
}
