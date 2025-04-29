using Mud.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Dto.Account;

public class RegisterDto
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be at least 4 characters long and less than 20 characters")]
    [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "Username can only contain letters, numbers, underscores, and hyphens.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [PasswordValidation(ErrorMessage = "Password must contain at least one digit and be at least 8 characters long.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}