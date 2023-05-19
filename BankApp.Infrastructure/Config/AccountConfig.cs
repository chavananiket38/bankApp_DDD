using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Infrastructure.EntityConfigurations
{
    internal class BankAccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("BankAccount");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();


            builder.Property(b => b.AccountNumber)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(b => b.FirstName);
            builder.Property(b => b.LastName);
            builder.Property(b => b.Password);
            builder.Property(b => b.Gender);
            builder.Property(b => b.City);
            builder.Property(b => b.AccountLimit);
        }
    }
}