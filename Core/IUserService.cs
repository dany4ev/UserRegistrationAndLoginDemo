using System.Threading.Tasks;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Core.IService
{
    public interface IUserService
    {
        Task<UserCreationResponse> CreateUserAsync(UserCredentialDto userCredentialsDto);

        Task<SignInResponse> SigninUserAsync(UserLoginDto userCredentialsDto);

        bool ValidateToken(string token);
    }
}
