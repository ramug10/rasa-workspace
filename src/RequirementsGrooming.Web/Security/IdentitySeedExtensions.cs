using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RequirementsGrooming.Infrastructure.Data;

namespace RequirementsGrooming.Web.Security;

public static class IdentitySeedExtensions
{
    public static async Task SeedIdentityAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var roles = new[] { "Stakeholder", "ProductOwner", "DevLead", "Approver", "Producer", "QA", "DevOps" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        await EnsureUserWithRolesAsync(userManager, "stakeholder@local.dev", "P@ssword123", new[] { "Stakeholder" });
        await EnsureUserWithRolesAsync(userManager, "productowner@local.dev", "P@ssword123", new[] { "ProductOwner", "Producer" });
        await EnsureUserWithRolesAsync(userManager, "approver@local.dev", "P@ssword123", new[] { "Approver" });
        await EnsureUserWithRolesAsync(userManager, "devlead@local.dev", "P@ssword123", new[] { "DevLead" });
        await EnsureUserWithRolesAsync(userManager, "qa@local.dev", "P@ssword123", new[] { "QA" });
        await EnsureUserWithRolesAsync(userManager, "devops@local.dev", "P@ssword123", new[] { "DevOps" });
    }

    private static async Task EnsureUserWithRolesAsync(
        UserManager<IdentityUser> userManager,
        string email,
        string password,
        IReadOnlyCollection<string> roles)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException($"Unable to seed user {email}: {string.Join(", ", createResult.Errors.Select(x => x.Description))}");
            }
        }

        foreach (var role in roles)
        {
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
