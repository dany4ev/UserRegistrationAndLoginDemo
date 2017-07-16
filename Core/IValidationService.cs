using merXcoin.DTO;
using System.Threading.Tasks;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Core.IService
{
    public interface IValidationService
    {
        Task<ValidationResponse> ValidateAsync(UserCredentialDto userCredentialsDto);
    }
}
