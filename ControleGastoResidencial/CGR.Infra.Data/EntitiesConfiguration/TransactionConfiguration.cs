using CGR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Infra.Data.EntitiesConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(400);

            builder.Property(t => t.Value)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(t => t.PurposeType)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(t => t.CategoryId)
                   .IsRequired();

            builder.Property(t => t.PersonId)
                   .IsRequired();

            // Transaction (N) -> Category (1)
            builder.HasOne(t => t.Category)
                   .WithMany()
                   .HasForeignKey(t => t.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Transaction (N) -> Person (1)
            // Person pode ter coleção Transactions (para cascade)
            builder.HasOne(t => t.Person)
                   .WithMany(p => p.Transactions)
                   .HasForeignKey(t => t.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
