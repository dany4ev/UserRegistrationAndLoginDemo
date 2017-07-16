using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAndLoginDemo.DTO
{
    public class UserLoginDto
    {
        const string EmailRegEx = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        const string MaxLengthError = "It could not be long 50 chars.";
        const string MinLengthError = "It must be minimum 3 chars.";
        const string EmailError = "Email must be valid.";

        [MaxLength(50, ErrorMessage = MaxLengthError),
            MinLength(3, ErrorMessage = MinLengthError),
            RegularExpression(EmailRegEx, ErrorMessage = EmailError),
            Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}

