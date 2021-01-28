using System.ComponentModel.DataAnnotations;

namespace BlazorBattles.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
    }
}
