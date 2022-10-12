using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = 1,
            Email = "test.test@test.com",
            FirstName = "Test",
            LastName = "Test",
            RoleId = 1,
            CratedAt = DateTime.Now
        });
    }
}