using Microsoft.EntityFrameworkCore;
using P013KatmanliBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P013KatmanliBlog.Data
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=P013KatmanliBlog; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Property(n => n.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Post>().Property(d=>d.Description).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().HasData(new User 
            { 
                Id=1,
                Name="Admin",
                Email="info@P013KatmanliBlog.com",
                Password="123",
                IsActive=true,
                IsAdmin=true,
                UserGuid =Guid.NewGuid(),
                UserName="Admin"            
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

    }

}
