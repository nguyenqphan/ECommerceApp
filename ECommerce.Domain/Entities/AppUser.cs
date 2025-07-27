using Microsoft.AspNetCore.Identity;


namespace ECommerce.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        // Add custom fields if needed (e.g., FirstName, LastName)
        public string? FullName { get; set; }
    }
}
