using System.Configuration;
using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Web.Http;

namespace DreamStream.Portal.Api
{
    public partial class Startup
    {
        //private static readonly string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        //private static readonly string AadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        //private static readonly string TenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        //private static readonly string PostLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        //private static readonly string Authority = AadInstance + TenantId;

        public static void ConfigureAuth(IAppBuilder app)
        {           
            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions());

            //app.UseOpenIdConnectAuthentication(
            //    new OpenIdConnectAuthenticationOptions
            //    {
            //        ClientId = ClientId,
            //        Authority = Authority,
            //        PostLogoutRedirectUri = PostLogoutRedirectUri
            //    });
        }
    }
}
