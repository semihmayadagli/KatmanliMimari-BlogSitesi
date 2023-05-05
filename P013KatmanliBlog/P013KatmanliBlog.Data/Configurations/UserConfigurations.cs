using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P013KatmanliBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P013KatmanliBlog.Data.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(n => n.Name).IsRequired().HasMaxLength(50);
            builder.Property(s=>s.Surname).HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(50);
            builder.Property(s => s.UserName).HasMaxLength(50);
            builder.Property(s => s.PhoneNumber).HasMaxLength(50);

            builder.HasData(new User
            {
                Id = 2,
                Name = "Admin2",
                Email = "info2@P013KatmanliBlog.com",
                Password = "123",
                IsActive = true,
                IsAdmin = true,
                UserGuid = Guid.NewGuid(),
                UserName = "Admin2"
            });

        }
    }
}
