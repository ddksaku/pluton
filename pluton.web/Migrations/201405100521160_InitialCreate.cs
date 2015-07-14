namespace pluton.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreakdownReasons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BreakdownResonDescription = c.String(),
                        Active = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BrokenElements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ElementDescription = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        LastActive = c.DateTime(nullable: false),
                        FailedLoginAttempts = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ClientStationId = c.Int(nullable: false),
                        DefaultLanguage = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                        Role_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.UserRoles", t => t.Role_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryShort = c.String(),
                        CountryLong = c.String(),
                        Pole = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Region = c.String(),
                        ZipPadding = c.Int(nullable: false),
                        Language = c.String(),
                        LanguageShort = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReferenceType = c.String(),
                        RoleName = c.String(),
                        AccessFlags = c.Int(nullable: false),
                        RoleFlag = c.Int(nullable: false),
                        DefaultHomepage = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CertificateSkills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CertificateSkillDescription = c.String(),
                        Permament = c.Boolean(nullable: false),
                        TimeBound = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CertificateType_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificateTypes", t => t.CertificateType_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .Index(t => t.CertificateType_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.CertificateTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CertificateTypeDescription = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Path = c.String(),
                        ReferenceId = c.Int(nullable: false),
                        ImageTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Lon = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personels", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                        ClientStationId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        MobileEnabled = c.Boolean(nullable: false),
                        MobilePass = c.String(),
                        VehicleNumber = c.String(),
                        Email = c.String(),
                        EmployeeNumber = c.String(),
                        PrivatePhoneNo = c.String(),
                        PersonalAddress = c.String(),
                        DefaultLang = c.String(),
                        Position = c.String(),
                        IceContact = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Vehicle_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleLicenseNo = c.String(),
                        HasLift = c.Boolean(nullable: false),
                        HasFlashers = c.Boolean(nullable: false),
                        RadioNumber = c.String(),
                        Reference = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Notes = c.String(),
                        ClientStationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        VehicleType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.VehicleType_Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleTypeDescription = c.String(),
                        Active = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MobileDataSubmissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        OperatorNotes = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        PhoneNumber = c.String(),
                        SubmissionTime = c.DateTime(nullable: false),
                        StartSwitch = c.Int(nullable: false),
                        EndSwitch = c.Int(nullable: false),
                        VehicleLicenseNo = c.String(),
                        TaskRealized = c.Boolean(nullable: false),
                        GpsFixTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Personel_Id = c.Guid(),
                        Task_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personels", t => t.Personel_Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Personel_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClientStationId = c.Int(nullable: false),
                        TaskDescription = c.String(),
                        CoordinatorId = c.Int(nullable: false),
                        AiesOrderReference = c.String(),
                        RegionId = c.Int(nullable: false),
                        TaskTypeId = c.Int(nullable: false),
                        UnitsOfTaskSort = c.Double(nullable: false),
                        TaskSortId = c.Int(nullable: false),
                        BreakdownTime = c.DateTime(nullable: false),
                        BrokenElementId = c.Int(nullable: false),
                        TeamSize = c.Int(nullable: false),
                        PlannedExecutionDate = c.DateTime(nullable: false),
                        ProjectedTeamDepartureDate = c.DateTime(nullable: false),
                        ActualTeamDepartureDate = c.DateTime(nullable: false),
                        EstStartTravelTimeMins = c.Int(nullable: false),
                        EstTaskPerformanceTimeMins = c.Int(nullable: false),
                        EstEndTravelTimeMins = c.Int(nullable: false),
                        SwitchStartFlag = c.Int(nullable: false),
                        SwitchEndFlag = c.Int(nullable: false),
                        SpecialEquipment = c.Int(nullable: false),
                        ActTeamArrivalTime = c.DateTime(nullable: false),
                        ActualTaskEndTime = c.DateTime(nullable: false),
                        LastTaskOnShiftFlag = c.Int(nullable: false),
                        Notes = c.String(),
                        KpiExcludedFlag = c.Boolean(nullable: false),
                        VehicleLicenceNumebr = c.String(),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        SwitchFinalCompletionDate = c.DateTime(nullable: false),
                        BreakdownReasonId = c.Int(nullable: false),
                        OperatorNotes = c.String(),
                        MediumVoltageLineId = c.Int(nullable: false),
                        RapidNotificationFlag = c.Int(nullable: false),
                        RegionTerritory = c.String(),
                        RealizedStatus = c.Int(nullable: false),
                        UnfilledDeletion = c.Int(nullable: false),
                        ReturnToCentralStation = c.DateTime(nullable: false),
                        CompletionTimeArranagements = c.DateTime(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        KpiExclusionApproved = c.Int(nullable: false),
                        KpiExclusionApprovedBy = c.Int(nullable: false),
                        NewTaskFlag = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                        TaskEntrySpecialist_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.DeletedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Personels", t => t.TaskEntrySpecialist_Id)
                .Index(t => t.DeletedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.TaskEntrySpecialist_Id);
            
            CreateTable(
                "dbo.MobileStatusChecks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PhoneNumber = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        GpsFixTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Personel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Personels", t => t.Personel_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Personel_Id);
            
            CreateTable(
                "dbo.OrgUnits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UnitDescription = c.String(),
                        UnitCity = c.String(),
                        UnitAddress = c.String(),
                        UnitPostalCode = c.String(),
                        UnitTelephoneNo = c.String(),
                        UnitKeyContactPerson = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        OrgUnitType_Id = c.Guid(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrgUnitTypes", t => t.OrgUnitType_Id)
                .ForeignKey("dbo.OrgUnits", t => t.Parent_Id)
                .Index(t => t.OrgUnitType_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.OrgUnitTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OperatingUnitDescription = c.String(),
                        HierachyOrder = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrgUnitTypes", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.PersonelSkillCertifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CertificateSkill_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        Personel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificateSkills", t => t.CertificateSkill_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Personels", t => t.Personel_Id)
                .Index(t => t.CertificateSkill_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Personel_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegionName = c.String(),
                        Active = c.Boolean(nullable: false),
                        ClientStationId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShiftName = c.String(),
                        ShiftFrom = c.Int(nullable: false),
                        ShiftTo = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        KpiExcluded = c.Boolean(nullable: false),
                        NightShift = c.Boolean(nullable: false),
                        NoWorkShift = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShiftAssignments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShiftStartDate = c.DateTime(nullable: false),
                        ClientStationId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Personel_Id = c.Guid(),
                        Shift_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Personels", t => t.Personel_Id)
                .ForeignKey("dbo.Shifts", t => t.Shift_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Personel_Id)
                .Index(t => t.Shift_Id);
            
            CreateTable(
                "dbo.SpecialEquipments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SpecialEquipmentName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.TaskPersonAssignments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SupervisorFlag = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Personel_Id = c.Guid(),
                        Task_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Personels", t => t.Personel_Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Personel_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.TaskSorts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaskSortDescription = c.String(),
                        UomTypeId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IconNumber = c.String(),
                        TaskReportingType = c.Int(nullable: false),
                        TaskSortGroup = c.Int(nullable: false),
                        ReferenceId = c.String(),
                        TravelStdTime = c.Int(nullable: false),
                        StandardTimeMins = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        TaskSortType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.TaskSortTypes", t => t.TaskSortType_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.TaskSortType_Id);
            
            CreateTable(
                "dbo.TaskSortTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaskSortTypeDescription = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        AllowMassDelete = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserOrgSelections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        OrgUnit_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrgUnits", t => t.OrgUnit_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.OrgUnit_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserPasswordRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IpAddress = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Succedded = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        ClientStationId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Rejected = c.Boolean(nullable: false),
                        RejectReason = c.String(),
                        CompletedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRequests", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.UserOrgSelections", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserOrgSelections", "OrgUnit_Id", "dbo.OrgUnits");
            DropForeignKey("dbo.TaskSorts", "TaskSortType_Id", "dbo.TaskSortTypes");
            DropForeignKey("dbo.TaskSorts", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.TaskPersonAssignments", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TaskPersonAssignments", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.TaskPersonAssignments", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.SpecialEquipments", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.ShiftAssignments", "Shift_Id", "dbo.Shifts");
            DropForeignKey("dbo.ShiftAssignments", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.ShiftAssignments", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Regions", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.PersonelSkillCertifications", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.PersonelSkillCertifications", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.PersonelSkillCertifications", "CertificateSkill_Id", "dbo.CertificateSkills");
            DropForeignKey("dbo.OrgUnits", "Parent_Id", "dbo.OrgUnits");
            DropForeignKey("dbo.OrgUnits", "OrgUnitType_Id", "dbo.OrgUnitTypes");
            DropForeignKey("dbo.OrgUnitTypes", "Parent_Id", "dbo.OrgUnitTypes");
            DropForeignKey("dbo.MobileStatusChecks", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.MobileStatusChecks", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.MobileDataSubmissions", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "TaskEntrySpecialist_Id", "dbo.Personels");
            DropForeignKey("dbo.Tasks", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "DeletedBy_Id", "dbo.Users");
            DropForeignKey("dbo.MobileDataSubmissions", "Personel_Id", "dbo.Personels");
            DropForeignKey("dbo.Images", "CreatedBy_Id", "dbo.Personels");
            DropForeignKey("dbo.Personels", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Personels", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.CertificateSkills", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.CertificateSkills", "CertificateType_Id", "dbo.CertificateTypes");
            DropForeignKey("dbo.BrokenElements", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "Country_Id", "dbo.Countries");
            DropIndex("dbo.UserRequests", new[] { "User_Id" });
            DropIndex("dbo.UserRequests", new[] { "Country_Id" });
            DropIndex("dbo.UserOrgSelections", new[] { "User_Id" });
            DropIndex("dbo.UserOrgSelections", new[] { "OrgUnit_Id" });
            DropIndex("dbo.TaskSorts", new[] { "TaskSortType_Id" });
            DropIndex("dbo.TaskSorts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.TaskPersonAssignments", new[] { "Task_Id" });
            DropIndex("dbo.TaskPersonAssignments", new[] { "Personel_Id" });
            DropIndex("dbo.TaskPersonAssignments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SpecialEquipments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.ShiftAssignments", new[] { "Shift_Id" });
            DropIndex("dbo.ShiftAssignments", new[] { "Personel_Id" });
            DropIndex("dbo.ShiftAssignments", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Regions", new[] { "CreatedBy_Id" });
            DropIndex("dbo.PersonelSkillCertifications", new[] { "Personel_Id" });
            DropIndex("dbo.PersonelSkillCertifications", new[] { "CreatedBy_Id" });
            DropIndex("dbo.PersonelSkillCertifications", new[] { "CertificateSkill_Id" });
            DropIndex("dbo.OrgUnitTypes", new[] { "Parent_Id" });
            DropIndex("dbo.OrgUnits", new[] { "Parent_Id" });
            DropIndex("dbo.OrgUnits", new[] { "OrgUnitType_Id" });
            DropIndex("dbo.MobileStatusChecks", new[] { "Personel_Id" });
            DropIndex("dbo.MobileStatusChecks", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Tasks", new[] { "TaskEntrySpecialist_Id" });
            DropIndex("dbo.Tasks", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Tasks", new[] { "DeletedBy_Id" });
            DropIndex("dbo.MobileDataSubmissions", new[] { "Task_Id" });
            DropIndex("dbo.MobileDataSubmissions", new[] { "Personel_Id" });
            DropIndex("dbo.Vehicles", new[] { "VehicleType_Id" });
            DropIndex("dbo.Vehicles", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Personels", new[] { "Vehicle_Id" });
            DropIndex("dbo.Personels", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Images", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CertificateSkills", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CertificateSkills", new[] { "CertificateType_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "Country_Id" });
            DropIndex("dbo.BrokenElements", new[] { "CreatedBy_Id" });
            DropTable("dbo.UserRequests");
            DropTable("dbo.UserPasswordRequests");
            DropTable("dbo.UserOrgSelections");
            DropTable("dbo.TaskSortTypes");
            DropTable("dbo.TaskSorts");
            DropTable("dbo.TaskPersonAssignments");
            DropTable("dbo.SpecialEquipments");
            DropTable("dbo.ShiftAssignments");
            DropTable("dbo.Shifts");
            DropTable("dbo.Regions");
            DropTable("dbo.PersonelSkillCertifications");
            DropTable("dbo.OrgUnitTypes");
            DropTable("dbo.OrgUnits");
            DropTable("dbo.MobileStatusChecks");
            DropTable("dbo.Tasks");
            DropTable("dbo.MobileDataSubmissions");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Personels");
            DropTable("dbo.Images");
            DropTable("dbo.CertificateTypes");
            DropTable("dbo.CertificateSkills");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Countries");
            DropTable("dbo.Users");
            DropTable("dbo.BrokenElements");
            DropTable("dbo.BreakdownReasons");
        }
    }
}
