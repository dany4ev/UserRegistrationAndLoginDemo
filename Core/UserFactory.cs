using System;

namespace UserRegistrationAndLoginDemo.Services.Factories
{
    public class UserFactory
    {
        public static string Create() => 
            $"user_{Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, 4)}";
    }
}
