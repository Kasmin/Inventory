using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);
            // Password -- User!123
            builder.HasData(
                new User()
                {
                    Id = new Guid("7d026625-3759-435e-9411-08d667f56c42"),
                    UserName = "user@user.ru",
                    Email = "user@user.ru",
                    NormalizedEmail = "USER@USER.RU",
                    NormalizedUserName = "USER@USER.RU",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SecurityStamp = "PTY4YHQHQOBOTTKVGZUKUCQVK2GAPPS5",
                    PasswordHash = "AQAAAAEAACcQAAAAEG0qRduIF1IoSaSKLwjNralERLDt62StIlFFIA2V77c1dV1qJrw/SemWIWrWeOtyLw=="
                }
            );
        }
    }
}
