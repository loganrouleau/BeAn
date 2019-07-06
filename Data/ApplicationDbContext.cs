using BeAn.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAn.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Target> Targets { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionData> SessionDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Program>()
                .Property(p => p.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<Student>()
                .Property(s => s.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<Target>()
                .Property(t => t.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<Session>()
                .Property(t => t.StartDateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<Session>()
                .Property(t => t.EndDateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<SessionData>()
                .Property(t => t.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("datetime('now')");

            modelBuilder.Entity<Program>().HasData(
                new { Id = -1, Name = "Program B", Description = "words", ProgramComplete = 0, MasteryCriteriaCompareType = 2, MasteryCriteriaCompareTo = 2.03, MasteryCriteriaConsecutiveSessions = 3, StudentId = -1 },
                new { Id = -2, Name = "Program C", Description = "morewords", ProgramComplete = 1, MasteryCriteriaCompareType = 2, MasteryCriteriaCompareTo = 2.33, MasteryCriteriaConsecutiveSessions = 4, StudentId = -2 },
                new { Id = -3, Name = "Program A", Description = "descwords", ProgramComplete = 0, MasteryCriteriaCompareType = 1, MasteryCriteriaCompareTo = 1.0, MasteryCriteriaConsecutiveSessions = 5, StudentId = -1 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = -1, StudentId = "id1", StudentInitial = "A.A", Remark = "Hi" },
                new Student() { Id = -2, StudentId = "id2", StudentInitial = "B.B", Remark = "Hello" },
                new Student() { Id = -3, StudentId = "id3", StudentInitial = "C.C", Remark = "Bye" }
            );

            modelBuilder.Entity<Target>().HasData(
                new
                {
                    Id = -1,
                    Name = "targetName1",
                    Type = "targettype1",
                    PromptLevel = "promptlevel1",
                    MinTrial = 2,
                    MaxTrial = 4,
                    ProgramId = -3
                },
                new
                {
                    Id = -2,
                    Name = "targetName2",
                    Type = "targettype2",
                    PromptLevel = "promptlevel2",
                    MinTrial = 1,
                    MaxTrial = 5,
                    ProgramId = -2
                }
            );

            modelBuilder.Entity<Session>().HasData(
                new { Id = -1, Description = "id1", StudentId = -3 }
            );

            modelBuilder.Entity<SessionData>().HasData(
                new { Id = -1, Data = 453, SessionId = -1, ProgramId = -2, TargetId = -2 }
            );
        }
    }
}
