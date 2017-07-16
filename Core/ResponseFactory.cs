using Microsoft.WindowsAzure.Storage.Table;
using UserRegistrationAndLoginDemo.DTO;
using UserRegistrationAndLoginDemo.Common.Security;

namespace UserRegistrationAndLoginDemo.Services.Factories
{
    public class ResponseFactory
    {
        static string ERRORMESSAGE = "Process Failed";
        static string SUCCESSMESSAGE = "Process succeeded";

        public ResponseFactory()
        {
        }

        public static void GenerateHashWithUserResponse(UserCredentialDto userCredentialsDto)
        {
            var hash = SecurityManager.HashPassword(userCredentialsDto.Password.Trim(), 12);
            userCredentialsDto.Salt = hash.Salt;
            userCredentialsDto.Password = hash.HashedPassword;
        }

        public static object GenerateSaveResponse<T>(ref T typedResponse, TableResult response)
        {
            if (typedResponse is UserCreationResponse)
            {
                var userCreationResponse = new UserCreationResponse
                {
                    Message = GetResponseMessage(response)
                };

                return userCreationResponse;
            }

            return null;
        }


        static string GetResponseMessage(TableResult response) =>
            response.HttpStatusCode.Equals(200) || response.HttpStatusCode.Equals(204) ? SUCCESSMESSAGE : ERRORMESSAGE;

    }
}
