#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LoginUser
{
    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    public string Email {get ; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "must be correct password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}