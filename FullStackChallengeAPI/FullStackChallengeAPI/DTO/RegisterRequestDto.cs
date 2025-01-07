using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FullStackChallengeAPI.DTO;

public class RegisterRequestDto
{
    [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.", MinimumLength = 2)]

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.", MinimumLength = 2)]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "E-mail is not valid")]
    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string? Mobile { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }
}