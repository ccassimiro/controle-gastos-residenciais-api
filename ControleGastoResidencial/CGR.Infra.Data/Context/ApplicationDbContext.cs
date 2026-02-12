using CGR.Domain.Entities;
using CGR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PersonTotalSummary> PersonTotalSummaries => Set<PersonTotalSummary>();
        public DbSet<CategoryTotalSummary> CategoriesTotalSummaries => Set<CategoryTotalSummary>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // diz pro EF que não é view/tabela
            modelBuilder.Entity<PersonTotalSummary>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });
            modelBuilder.Entity<CategoryTotalSummary>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });
            //

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}