namespace UserRegistrationAndLoginDemo.Common.Security
{

    public class ValidatePasswordModel
    {
        public string HashedPassword { get; internal set; }

        public string Salt { get; set; }

        public int SaltSize { get; set; }
    }
}