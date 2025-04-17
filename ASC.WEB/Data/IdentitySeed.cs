using ASC.Model.BaseTypes;
using ASC.WEB.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using ASC.WEB.Models;

namespace ASC.WEB.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        private readonly ILogger<IdentitySeed> _logger;

        public IdentitySeed(ILogger<IdentitySeed> logger)
        {
            _logger = logger;
        }

        public async Task Seed(UserManager<IdentityUser> userManager,
                       RoleManager<IdentityRole> roleManager,
                       IOptions<ApplicationSettings> options)

        {
            var roles = options.Value.Roles?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];

            foreach (var role in roles)
            {
                try
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        IdentityRole storageRole = new IdentityRole { Name = role };
                        IdentityResult roleResult = await roleManager.CreateAsync(storageRole);

                        if (!roleResult.Succeeded)
                        {
                            _logger.LogError("Lỗi khi tạo vai trò {Role}: {Errors}", role, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi tạo vai trò {Role}", role);
                }
            }

            await CreateUserIfNotExists(userManager, options.Value.AdminEmail, options.Value.AdminName, options.Value.AdminPassword, Roles.Admin.ToString());
            await CreateUserIfNotExists(userManager, options.Value.EngineerEmail, options.Value.EngineerName, options.Value.EngineerPassword, Roles.Engineer.ToString());
            
        }

        private async Task CreateUserIfNotExists(UserManager<IdentityUser> userManager, string email, string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) return;

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", email));
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsActive", "True"));
                }
                else
                {
                    _logger.LogError("Lỗi khi tạo người dùng {Email}: {Errors}", email, string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
