using Microsoft.AspNetCore.Identity;

namespace ASC.WEB.Areas.Accounts.Models
{
    public class CustomerViewModel
    {
        public List<IdentityUser>? Customers { get; set; }
        public CustomerRegistrationViewModel Registration { get; set; }
    }
}
