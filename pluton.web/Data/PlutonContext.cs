using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using pluton.dal.Entities;

namespace pluton.web.Data
{
    public class PlutonContext : DbContext
    {
        public DbSet<BreakdownReason> BreakdownReason { get; set; }
        public DbSet<BrokenElement> BrokenElement { get; set; }
        public DbSet<CertificateSkill> CertificateSkill { get; set; }
        public DbSet<CertificateType> CertificateType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<MobileDataSubmission> MobileDataSubmission { get; set; }
        public DbSet<MobileStatusCheck> MobileStatusCheck { get; set; }
        public DbSet<OrgUnit> OrgUnit { get; set; }
        public DbSet<OrgUnitType> OrgUnitType { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelSkillCertification> PersonelSkillCertification { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<ShiftAssignment> ShiftAssignment { get; set; }
        public DbSet<SpecialEquipment> SpecialEquipment { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskPersonAssignment> TaskPersonAssignment { get; set; }
        public DbSet<TaskSort> TaskSort { get; set; }
        public DbSet<TaskSortType> TaskSortType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOrgSelection> UserOrgSelection { get; set; }
        public DbSet<UserPasswordRequest> UserPasswordRequest { get; set; }
        public DbSet<UserRequest> UserRequest { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<LocalizationResource> LocalizationResource { get; set; }
        public DbSet<AccessLogItem> AccessLogItem { get; set; }
    }
}