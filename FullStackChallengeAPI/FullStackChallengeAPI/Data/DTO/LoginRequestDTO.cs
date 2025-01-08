using System.ComponentModel.DataAnnotations;

namespace FullStackChallengeAPI.Data.DTO;

public class LoginRequestDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}