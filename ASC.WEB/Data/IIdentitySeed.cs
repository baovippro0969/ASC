using ASC.WEB.Configuration;
using ASC.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace ASC.WEB.Data
{
    public interface IIdentitySeed
    {
        Task Seed(UserManager<IdentityUser> userManager,
                  RoleManager<IdentityRole> roleManager,
                  IOptions<ApplicationSettings> options);
    }
}
