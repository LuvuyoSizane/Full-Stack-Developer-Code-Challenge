using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackChallengeAPI.Entity;

public class User
{
    [Key]
    [JsonPropertyName("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.", MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    
    [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.", MinimumLength = 2)]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "E-mail is not valid")]
    [Display(Name = "Email Address")]
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    public string? Mobile { get; set; } 
    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
    public string? Salt { get; set; } // Matches 'salt'
    public string? Token { get; set; } // Matches 'token'
}