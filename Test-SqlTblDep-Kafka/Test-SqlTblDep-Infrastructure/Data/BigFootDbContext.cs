using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test_SqlTblDep_Infrastructure.Entities;

namespace Test_SqlTblDep_Infrastructure.Data
{
    public class BigFootDbContext : DbContext
    {
        public BigFootDbContext()
        {

        }

        public DbSet<BigFoot> BigFoot { get; set; }
        public DbSet<EyeColor> EyeColor { get; set; }

        public BigFootDbContext(DbContextOptions<BigFootDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=bigfoot;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed
            modelBuilder.Entity<EyeColor>().HasData(
                new EyeColor() { Id = Guid.NewGuid(), Color = "Brown" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Blue" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Grey" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Yello" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Red" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Green" },
                new EyeColor() { Id = Guid.NewGuid(), Color = "Pink" }
                );
            #endregion
        }



    }
}
