using FluentValidation;
using userRole.Data.Dtos;
using userRole.Models;

namespace userRole.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().Must(IsValidEmail).WithMessage("Email is required and must be valid");
            RuleFor(x => x.Password).NotEmpty().Must(IsValidPassword).WithMessage("Password is required and must have at least 6 characters, one uppercase letter, one lowercase letter, and one special character");
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var hasUpperCase = false;
            var hasLowerCase = false;
            var hasDigit = false;
            var hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (char.IsPunctuation(c) || char.IsSymbol(c))
                {
                    hasSpecialChar = true;
                }
            }

            return password.Length >= 6 && hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}
