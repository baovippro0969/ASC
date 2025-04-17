using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static CurrentUser GetCurrentUserDetails(this ClaimsPrincipal principal)
        {
            if (!principal.Claims.Any())
            {
                return null;
            }

            return new CurrentUser
            {
                Name = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value,
                Email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                Roles = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray(),
                IsActive = Boolean.Parse(principal.Claims.Where(c => c.Type == "IsActive").Select(c => c.Value).SingleOrDefault()),
            };
        }
    }
}
