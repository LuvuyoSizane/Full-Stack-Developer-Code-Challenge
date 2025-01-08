using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullStackChallengeAPI.Entity;

public class User
{
    [Key]
    [JsonPropertyName("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id { get; set; } = Guid.NewGuid();
    [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.", MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string firstname { get; set; }
    
    [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters.", MinimumLength = 2)]
    [JsonPropertyName("lastName")]
    public string lastname { get; set; }
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "E-mail is not valid")]
    [Display(Name = "Email Address")]
    [EmailAddress]
    [Required]
    public string? email { get; set; }
    public string? mobile { get; set; } 
    [Required]
    [MinLength(6)]
    public required string password { get; set; }
    public string? salt { get; set; } // Matches 'salt'
    public string? token { get; set; } // Matches 'token'
}