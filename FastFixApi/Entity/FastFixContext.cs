using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFixApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFixApi.Entity
{
    public class FastFixContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceSubCategory>()
                .HasOne<ServiceCategory>(s => s.ServiceCategory)
                .WithMany(g => g.SubCategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

           
        }
        public  FastFixContext (DbContextOptions options) : base(options) { }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }
    }
}
