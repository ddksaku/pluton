using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars.Common;

namespace pluton.dal.Entities
{
    public class Task: EntityBase<Guid>
    {
        public int ClientStationId { get; set; }
        public string TaskDescription { get; set; } // CharLength:300
        public int CoordinatorId { get; set; }
        public string AiesOrderReference { get; set; } // CharLength:50
        public int RegionId { get; set; }
        public int TaskTypeId { get; set; }
        public double UnitsOfTaskSort { get; set; }
        public int TaskSortId { get; set; }
        public DateTime BreakdownTime { get; set; }
        public int BrokenElementId { get; set; }
        public int TeamSize { get; set; }
        public DateTime PlannedExecutionDate { get; set; }
        public DateTime ProjectedTeamDepartureDate { get; set; }
        public DateTime ActualTeamDepartureDate { get; set; }
        public int EstStartTravelTimeMins { get; set; }
        public int EstTaskPerformanceTimeMins { get; set; }
        public int EstEndTravelTimeMins { get; set; }
        public int SwitchStartFlag { get; set; } // nullable:NO
        public int SwitchEndFlag { get; set; } // nullable:NO
        public int SpecialEquipment { get; set; } // nullable:NO
        // delete field - public DateTime ActTeamDepartureTime { get; set; } 
        public DateTime ActTeamArrivalTime { get; set; }
        public DateTime ActualTaskEndTime { get; set; }
        public int LastTaskOnShiftFlag { get; set; }
        public string Notes { get; set; } // CharLength:1000
        public bool KpiExcludedFlag { get; set; } // nullable:NO
        public string VehicleLicenceNumebr { get; set; } // CharLength:50
        public DateTime LastUpdatedDate { get; set; }
        public User LastUpdatedBy { get; set; } // nullable:NO
        public User DeletedBy { get; set; } // nullable:NO
        public DateTime DeletedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; } // nullable:NO
        public DateTime SwitchFinalCompletionDate { get; set; }
        public int BreakdownReasonId { get; set; }
        public string OperatorNotes { get; set; } // CharLength:1000
        public int MediumVoltageLineId { get; set; }
        public int RapidNotificationFlag { get; set; } // nullable:NO
        public string RegionTerritory { get; set; } // CharLength:100
        public int RealizedStatus { get; set; } // nullable:NO
        public int UnfilledDeletion { get; set; } // nullable:NO
        public DateTime ReturnToCentralStation { get; set; }
        public DateTime CompletionTimeArranagements { get; set; }
        public int VehicleId { get; set; } // nullable:NO
        public int KpiExclusionApproved { get; set; } // nullable:NO
        public int KpiExclusionApprovedBy { get; set; } // nullable:NO
        public Personel TaskEntrySpecialist { get; set; } // nullable:NO
        public bool NewTaskFlag { get; set; } // nullable:NO
    }
}
