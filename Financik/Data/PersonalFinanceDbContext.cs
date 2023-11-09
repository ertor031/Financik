using Financik.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financik.Data
{
    public class PersonalFinanceDbContext:DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeSource> IncomeSources { get; set; }
        public DbSet<User> Users { get; set; }
        public PersonalFinanceDbContext(DbContextOptions<PersonalFinanceDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>()
        .HasOne(i => i.IncomeSource)
        .WithMany(isr => isr.Incomes)
        .HasForeignKey(i => i.IncomeSourceId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cost>()
        .HasOne(c => c.Category)
        .WithMany(cat => cat.Costs)
        .HasForeignKey(c => c.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.Number)
                .IsUnique();
        }
    }
}
