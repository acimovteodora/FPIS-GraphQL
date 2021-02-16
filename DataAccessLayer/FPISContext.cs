using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace DataAccessLayer
{
    public class FPISContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ExternalMentor> ExternalMentors { get; set; }
        public DbSet<ExternalMentorContact> ExternalMentorContacts { get; set; }
        public DbSet<ScientificArea> ScientificAreas { get; set; }
        public DbSet<ProjectCoveringSubject> ProjectCoveringSubjects { get; set; }
        public DbSet<ProjectProposal> ProjectProposals { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectContract> ProjectContracts { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ProjectPlan> ProjectPlans { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Engagement> Engagements { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<ChangesReport> ChangesReports { get; set; }
        public FPISContext(DbContextOptions<FPISContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeePosition>().HasKey(e => new { e.EmployeeID, e.PositionID });
            modelBuilder.Entity<Location>().HasKey(l => new { l.CityID, l.CompanyID });
            modelBuilder.Entity<Contact>(b =>
            {
                b.HasKey(e => new { e.CompanyID, e.ContactID });
                b.Property(e => e.ContactID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ExternalMentor>(em =>
            {
                em.HasKey(e => new { e.CompanyID, e.MentorID });
                em.Property(e => e.MentorID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ExternalMentorContact>(emc =>
            {
                emc.HasKey(e => new { e.ExternalMentorCompanyID, e.ExternalMentorMentorID, e.SerialNumber });
                emc.Property(e => e.SerialNumber).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProjectCoveringSubject>(pcs =>
            {
                pcs.HasKey(e => new { e.ProjectProposalID, e.ProjectCoveringSubjectID });
                pcs.Property(e => e.ProjectCoveringSubjectID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Application>().HasKey(a => new { a.StudentID, a.ProjectID });
            modelBuilder.Entity<Document>(d =>
            {
                d.HasKey(a => new { a.ProjectID, a.DocumentID });
                d.Property(a => a.DocumentID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Phase>(p =>
            {
                p.HasKey(a => new { a.ProjectID, a.DocumentID, a.PhaseID });
                p.Property(a => a.PhaseID).ValueGeneratedOnAdd();
                p.HasOne(a => a.ProjectPlan)
                .WithMany(a => a.Phases).HasForeignKey(x => new { x.ProjectID, x.DocumentID });
            });
            modelBuilder.Entity<Engagement>(e =>
           {
               e.HasKey(a => new { a.ProjectID, a.DocumentID, a.PhaseID, a.StudentID });
               e.HasOne(a => a.Phase)
               .WithMany(a => a.Engagements).HasForeignKey(x => new { x.ProjectID, x.DocumentID, x.PhaseID });
           });
            modelBuilder.Entity<Skill>(s =>
            {
                s.HasKey(e => new { e.ProjectID, e.DocumentID, e.PhaseID, e.SkillID });
                s.Property(a => a.SkillID).ValueGeneratedOnAdd();
                s.HasOne(e => e.Phase)
                .WithMany(e => e.RequiredSkills).HasForeignKey(x => new { x.ProjectID, x.DocumentID, x.PhaseID });
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
