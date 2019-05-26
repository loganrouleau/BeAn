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

            modelBuilder.Entity<Program>().HasData(
                new { Id = -1, Name = "Program B", Description = "words", StudentId = -1 },
                new { Id = -2, Name = "Program C", Description = "morewords", StudentId = -2 },
                new { Id = -3, Name = "Program A", Description = "descwords", StudentId = -1 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = -1, StudentId = "id1", StudentInitial = "A.A", Remark = "Hi" },
                new Student() { Id = -2, StudentId = "id2", StudentInitial = "B.B", Remark = "Hello" },
                new Student() { Id = -3, StudentId = "id3", StudentInitial = "C.C", Remark = "Bye" }
            );
        }
    }
}
