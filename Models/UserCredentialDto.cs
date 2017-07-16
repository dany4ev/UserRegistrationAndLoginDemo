using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAndLoginDemo.DTO
{
    public class UserCredentialDto
    {
        const string EmailRegEx = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        const string StrongPasswordRegEx = @"^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8}$";
        const string MaxLengthError = "It could not be long 50 chars.";
        const string MinLengthError = "It must be minimum 3 chars.";
        const string EmailError = "Email must be valid.";
        const string StrongPasswordError = "Your password is weak or you don't have one!";
        const string ComparePasswordError = "Passwords must be same";

        [MaxLength(50, ErrorMessage = MaxLengthError), 
            MinLength(3, ErrorMessage = MinLengthError), 
            Required]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = MaxLengthError), 
            MinLength(3, ErrorMessage = MinLengthError), 
            Required]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = MaxLengthError), 
            MinLength(3, ErrorMessage = MinLengthError), 
            Required]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = MaxLengthError), 
            MinLength(3, ErrorMessage = MinLengthError), 
            RegularExpression(EmailRegEx, ErrorMessage = EmailError), 
            Required]
        public string Email { get; set; }

        [RegularExpression(StrongPasswordRegEx, ErrorMessage = StrongPasswordError),
            Required]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = ComparePasswordError),
            RegularExpression(StrongPasswordRegEx, ErrorMessage = StrongPasswordError),
            Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool Agree { get; set; }

        public bool IsStrong { get; set; }
        public string Salt { get; set; }
        public string Id { get; set; }
    }
}
