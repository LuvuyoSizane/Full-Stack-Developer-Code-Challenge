using System.ComponentModel.DataAnnotations;

namespace FullStackChallengeAPI.DTO;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}