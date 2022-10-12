using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using File = Entities.Models.File;
using Task = Entities.Models.Task;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<Permission>? Permissions { get; set; }
    public DbSet<Task>? Tasks { get; set; }
    public DbSet<File>? Files { get; set; }
}