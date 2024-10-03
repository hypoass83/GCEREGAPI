
using Insfrastructure.Entities.Localisation;
using Insfrastructure.Entities.Parameters;
using Insfrastructure.Entities.Parameters.Examiners;
using Insfrastructure.Entities.Parameters.Impairements;
using Insfrastructure.Entities.Registration;
using Insfrastructure.Entities.Security;
using Insfrastructure.Initialiser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Entities
{
    public class FsContext : DbContext
    {
        public FsContext(DbContextOptions<FsContext> options)
       : base(options)
        { }

        //securty module
        public DbSet<ActionMenuProfile> ActionMenuProfiles { get; set; }
        public DbSet<ActionSubMenuProfile> ActionSubMenuProfiles { get; set; }
        public DbSet<GlobalPerson> GlobalPeople { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Mouchard> Mouchards { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<User> Users { get; set; }

        //localisation
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubDivision> SubDivisions { get; set; }

        //Parameters/Examiners
        public DbSet<IndexCat> IndexCats { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<SelectedExaminer> SelectedExaminers { get; set; }
        //Parameters/Impairements
        public DbSet<Impairment> Impairments { get; set; }
        public DbSet<ImpairmentDegree> ImpairmentDegrees { get; set; }
        public DbSet<ImpairmentSupport> ImpairmentSupports { get; set; }
        //Parameters
        public DbSet<AcomCentre> AcomCentres { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamCentre> Examcentres { get; set; }
        public DbSet<ExamSession> ExamSessions { get; set; }
        public DbSet<Specialty> Specialies { get; set; }
        public DbSet<SpecSubject> SpecSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        //registration
        public DbSet<BannedCandidate> BannedCandidates { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandSubject> CandSubjects { get; set; }
        public DbSet<Examiner> Examiners { get; set; }
        public DbSet<ImpairmentCandidate> ImpairmentCandidates { get; set; }
        public DbSet<ValidateRegistration> ValidateRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GlobalPerson>().ToTable("GlobalPeople");
            modelBuilder.Entity<People>().ToTable("People");
            modelBuilder.Entity<User>().ToTable("Users");

            //security
            modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithMany()
            .HasForeignKey(u => u.ProfileID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SubMenu>()
            .HasOne(u => u.Menu)
            .WithMany()
            .HasForeignKey(u => u.MenuID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<People>()
                .HasOne(d => d.Sex)
                .WithMany()
                .HasForeignKey(d => d.SexID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Mouchard>()
                .HasOne(ut => ut.User)
                .WithMany() 
                .HasForeignKey(ut => ut.UserID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete

            modelBuilder.Entity<Mouchard>()
                .HasOne(ut => ut.Examcentre)
                .WithMany()
                .HasForeignKey(ut => ut.ExamcentreID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete

            modelBuilder.Entity<Menu>()
                .HasOne(ut => ut.Module)
                .WithMany()
                .HasForeignKey(ut => ut.ModuleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GlobalPerson>()
                .HasOne(ut => ut.Adress)
                .WithMany()
                .HasForeignKey(ut => ut.AdressID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ActionSubMenuProfile>()
               .HasOne(ut => ut.SubMenu)
               .WithMany()
               .HasForeignKey(ut => ut.SubMenuID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActionSubMenuProfile>()
               .HasOne(ut => ut.Profile)
               .WithMany()
               .HasForeignKey(ut => ut.ProfileID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ActionMenuProfile>()
              .HasOne(ut => ut.Menu)
              .WithMany()
              .HasForeignKey(ut => ut.MenuID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActionMenuProfile>()
               .HasOne(ut => ut.Profile)
               .WithMany()
               .HasForeignKey(ut => ut.ProfileID)
               .OnDelete(DeleteBehavior.NoAction);

            //registration
            modelBuilder.Entity<ValidateRegistration>()
               .HasOne(ut => ut.Candidate)
               .WithMany()
               .HasForeignKey(ut => ut.CandidateID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImpairmentCandidate>()
               .HasOne(ut => ut.Candidate)
               .WithMany()
               .HasForeignKey(ut => ut.CandidateID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImpairmentCandidate>()
               .HasOne(ut => ut.Impairment)
               .WithMany()
               .HasForeignKey(ut => ut.ImpairmentID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ImpairmentCandidate>()
               .HasOne(ut => ut.ImpairmentDegree)
               .WithMany()
               .HasForeignKey(ut => ut.ImpairmentDegreeID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ImpairmentCandidate>()
               .HasOne(ut => ut.ImpairmentSupport)
               .WithMany()
               .HasForeignKey(ut => ut.ImpairmentSupportID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.Exam)
               .WithMany()
               .HasForeignKey(ut => ut.ExamID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.ExamCentre)
               .WithMany()
               .HasForeignKey(ut => ut.ExamCentreID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.Qualification)
               .WithMany()
               .HasForeignKey(ut => ut.QualificationID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.IndexCat)
               .WithMany()
               .HasForeignKey(ut => ut.IndexCatID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.Subject)
               .WithMany()
               .HasForeignKey(ut => ut.SubjectID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.Specialty)
               .WithMany()
               .HasForeignKey(ut => ut.SpecialtyID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.Rank)
               .WithMany()
               .HasForeignKey(ut => ut.RankID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Examiner>()
               .HasOne(ut => ut.SubDivision)
               .WithMany()
               .HasForeignKey(ut => ut.SubDivisionID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CandSubject>()
              .HasOne(ut => ut.Candidate)
              .WithMany()
              .HasForeignKey(ut => ut.CandidateID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
              .HasOne(ut => ut.Exam)
              .WithMany()
              .HasForeignKey(ut => ut.ExamID)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Candidate>()
              .HasOne(ut => ut.ExamCentre)
              .WithMany()
              .HasForeignKey(ut => ut.ExamCentreID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
              .HasOne(ut => ut.SubDivision)
              .WithMany()
              .HasForeignKey(ut => ut.SubDivisionID)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Candidate>()
              .HasOne(ut => ut.Specialty)
              .WithMany()
              .HasForeignKey(ut => ut.SpecialtyID)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Candidate>()
              .HasOne(ut => ut.SpecialtyNA)
              .WithMany()
              .HasForeignKey(ut => ut.SpecialtyNAID)
              .OnDelete(DeleteBehavior.NoAction);
            //parameter
            modelBuilder.Entity<TimeTable>()
              .HasOne(ut => ut.Exam)
              .WithMany()
              .HasForeignKey(ut => ut.ExamID)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TimeTable>()
             .HasOne(ut => ut.Subject)
             .WithMany()
             .HasForeignKey(ut => ut.SubjectID)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecSubject>()
             .HasOne(ut => ut.Exam)
             .WithMany()
             .HasForeignKey(ut => ut.ExamID)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SpecSubject>()
             .HasOne(ut => ut.Subject)
             .WithMany()
             .HasForeignKey(ut => ut.SubjectID)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecSubject>()
             .HasOne(ut => ut.Specialty)
             .WithMany()
             .HasForeignKey(ut => ut.SpecialtyID)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecSubject>()
             .HasOne(ut => ut.SubjectGroup)
             .WithMany()
             .HasForeignKey(ut => ut.SubjectGroupID)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamSession>()
             .HasOne(ut => ut.ExamCentre)
             .WithMany()
             .HasForeignKey(ut => ut.ExamCentreID)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExamCentre>()
            .HasOne(ut => ut.Adress)
            .WithMany()
            .HasForeignKey(ut => ut.AdressID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamCentre>()
            .HasOne(ut => ut.AcomCentre)
            .WithMany()
            .HasForeignKey(ut => ut.AcomCentreID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamCentre>()
            .HasOne(ut => ut.User)
            .WithMany()
            .HasForeignKey(ut => ut.UserID)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AcomCentre>()
           .HasOne(ut => ut.Adress)
           .WithMany()
           .HasForeignKey(ut => ut.AdressID)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ImpairmentSupport>()
           .HasOne(ut => ut.Impairment)
           .WithMany()
           .HasForeignKey(ut => ut.ImpairmentID)
           .OnDelete(DeleteBehavior.NoAction);
            //localisation
            modelBuilder.Entity<SubDivision>()
           .HasOne(ut => ut.Division)
           .WithMany()
           .HasForeignKey(ut => ut.DivisionID)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Region>()
           .HasOne(ut => ut.Country)
           .WithMany()
           .HasForeignKey(ut => ut.CountryID)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Division>()
           .HasOne(ut => ut.Region)
           .WithMany()
           .HasForeignKey(ut => ut.RegionID)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Adress>()
           .HasOne(ut => ut.SubDivision)
           .WithMany()
           .HasForeignKey(ut => ut.SubDivisionID)
           .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
    }


}

