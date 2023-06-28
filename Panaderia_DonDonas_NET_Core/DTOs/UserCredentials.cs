using System.ComponentModel.DataAnnotations;

namespace Panaderia_DonDonas_NET_Core.DTOs
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
