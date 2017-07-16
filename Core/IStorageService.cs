using System.Threading.Tasks;
using UserRegistrationAndLoginDemo.Core.Model;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Core.IService
{
    public interface IStorageService
    {        

        Task<UserCredential> FindUserByEmailAsync(UserCredential userCredential);

        Task<UserCreationResponse> SaveToTableAsync(UserCredentialDto userCredentialsDto);
    }
}
