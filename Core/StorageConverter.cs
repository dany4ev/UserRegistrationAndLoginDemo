using UserRegistrationAndLoginDemo.Core.Model;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Services.Conversion
{
    public static class StorageConverter
    {
        public static UserCredential ConvertToModel(this UserCredentialDto userCredentialDto)
        {
            var userCredential = new UserCredential(userCredentialDto.UserName, userCredentialDto.Password)
            {
                FirstName = userCredentialDto.FirstName,
                LastName = userCredentialDto.LastName,
                Email = userCredentialDto.Email,
                Agree = userCredentialDto.Agree,
                Salt = userCredentialDto.Salt
            };

            return userCredential;
        }

        public static UserCredentialDto ConvertToDto(this UserCredential userCredential)
        {
            var userCredentialDto = new UserCredentialDto
            {
                FirstName = userCredential.FirstName,
                LastName = userCredential.LastName,
                Email = userCredential.Email,
                Agree = userCredential.Agree,
                Salt = userCredential.Salt
            };

            return userCredentialDto;
        }
    }
}
