using Microsoft.Owin;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CompleteSample.Authentication
{
    public class AuthenticationMiddleware : OwinMiddleware
    {
        public AuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            string[] values;
            BasicAuthenticationCredentials credentials;

            if (context.Request.Headers.TryGetValue("Authorization", out values)
                && BasicAuthenticationCredentials.TryParse(values.First(), out credentials)
                && Authenticate(credentials.UserName, credentials.Password))
            {
                var identity = new GenericIdentity(credentials.UserName);
                context.Request.User = new GenericPrincipal(identity, new string[0]);
            }
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
            }

            return Next.Invoke(context);
        }

        private static bool Authenticate(string userName, string password)
        {
            // TODO: use a better authentication mechanism ;-)

            return userName == "fvilers" && password == "test";
        }

    }
}
