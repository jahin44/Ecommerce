using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
    }
}
