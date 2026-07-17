using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RequirementsGrooming.Domain.Entities;

namespace RequirementsGrooming.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Requirement> Requirements => Set<Requirement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Requirement>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.ProjectName).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Title).HasMaxLength(250).IsRequired();
            entity.Property(x => x.BusinessGoal).HasMaxLength(2000).IsRequired();
            entity.Property(x => x.AcceptanceCriteria).HasMaxLength(4000).IsRequired();
            entity.Property(x => x.Priority).HasMaxLength(30).IsRequired();
            entity.Property(x => x.DecisionReason).HasMaxLength(1000);
        });
    }
}
