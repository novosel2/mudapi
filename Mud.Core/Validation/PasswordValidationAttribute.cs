using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Validation;

public class PasswordValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return false;
        }

        string password = value.ToString()!;

        // Check if the password is at least 8 characters long
        if (password.Length < 8)
        {
            return false;
        }

        // Check if the password contains at least one digit
        if (!password.Any(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}