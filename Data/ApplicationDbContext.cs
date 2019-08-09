using BeAn.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        public DbSet<Prompt> Prompts { get; set; }
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
            modelBuilder.Entity<Prompt>()
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

            TestDataPopulator.PopulateTestData(modelBuilder);
        }
    }
}
