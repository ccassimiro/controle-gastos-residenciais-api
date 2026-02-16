using CGR.Domain.Entities;
using CGR.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CGR.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Entidades reais
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        // Keyless query types
        public DbSet<PersonTotalSummary> PersonTotalSummaries => Set<PersonTotalSummary>();
        public DbSet<CategoryTotalSummary> CategoryTotalSummaries => Set<CategoryTotalSummary>();
        public DbSet<TotalsRow> TotalsRows => Set<TotalsRow>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonTotalSummary>(e =>
            {
                e.HasNoKey();
                e.ToView(null);
            });

            modelBuilder.Entity<CategoryTotalSummary>(e =>
            {
                e.HasNoKey();
                e.ToView(null);
            });

            modelBuilder.Entity<TotalsRow>(e =>
            {
                e.HasNoKey();
                e.ToView(null);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}