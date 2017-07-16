using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UserRegistrationAndLoginDemo.Core.IService;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Api.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("UserLogin")]
        public async Task<IHttpActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var signinResponse = await _userService.SigninUserAsync(userLoginDto);

                    if (string.IsNullOrEmpty(signinResponse.Token))
                    {
                        throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                        {
                            Content = new StringContent("Invalid user."),
                            ReasonPhrase = "Invalid user.",
                            StatusCode = System.Net.HttpStatusCode.Unauthorized,
                        });
                    }

                    return Ok(signinResponse);
                }
                return Ok();
            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPost, Route("UserRegistration")]
        public async Task<IHttpActionResult> UserRegistrationAsync(UserCredentialDto userCredentialsDto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var userResponse = await _userService.CreateUserAsync(userCredentialsDto);
                    return Ok(userResponse);
                }
                return InternalServerError();
            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
