using H5API.Repositories.Base;
using Microsoft.AspNetCore.Identity;

namespace H5API.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
