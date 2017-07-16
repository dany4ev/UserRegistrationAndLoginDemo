using System.Threading.Tasks;
using UserRegistrationAndLoginDemo.Common.Security;
using UserRegistrationAndLoginDemo.Core.IService;
using UserRegistrationAndLoginDemo.DTO;
using UserRegistrationAndLoginDemo.Services.Conversion;

namespace merXcoin.Services
{
    public class UserService : IUserService
    {
        readonly string _jwtSecretKey = ConfigurationService.JwtSecretKey;
        readonly IStorageService _storageService;

        public UserService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        
        public async Task<UserCreationResponse> CreateUserAsync(UserCredentialDto userCredentialsDto)
        {
            var saveResponse = await _storageService.SaveToTableAsync(userCredentialsDto);
            return saveResponse;
        }
                
        public async Task<SignInResponse> SigninUserAsync(UserLoginDto userLoginDto)
        {
            var userCredentialsDto = new UserCredentialDto
            {
                Email = userLoginDto.Email,
                Password = userLoginDto.Password
            };

            var userCredential = userCredentialsDto.ConvertToModel();
            var userData = await _storageService.FindUserByEmailAsync(userCredential);
            var signInResponse = new SignInResponse();
            if (userData != null)
            {
                var passwordModel = SecurityManager.HashPassword(userCredentialsDto.Password, userData.Salt);
                if (userData.RowKey == passwordModel.HashedPassword)
                {
                    signInResponse.Token = SecurityManager.GenerateToken(_jwtSecretKey, userData.ConvertToDto());                    
                }
            }
            return await Task.FromResult(signInResponse);
        }

        public bool ValidateToken(string token) => SecurityManager.IsTokenValid(token, _jwtSecretKey, true);
    }
}
