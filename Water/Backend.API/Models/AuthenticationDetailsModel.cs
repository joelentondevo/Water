using System.ComponentModel.DataAnnotations;

namespace Backend.API.Models
{
    public class AuthenticationDetailsModel
    {
        [Required]
        [MaxLength(140)]

        public string Username { get; set; }
        public string Password { get; set; }
    }
}

