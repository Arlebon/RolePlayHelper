using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.DL.Enums;

namespace RolePlayHelper.DAL.Database.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@admin.be",
                Role = Role.Admin,
                Password = Argon2.Hash("123"), 
            });

            builder.HasData(new User
            {
                Id = 2,
                UserName = "default",
                Email = "default@default.be",
                Role = Role.User,
                Password = Argon2.Hash("123"), // "123"

            });

        }
    }

}
