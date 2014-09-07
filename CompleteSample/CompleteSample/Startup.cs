using CompleteSample.Authentication;
using CompleteSample.Logging;
using Owin;
using System.Web.Http;

namespace CompleteSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.Use<LoggingMiddleware>();
            app.Use<AuthenticationMiddleware>();
            app.UseWebApi(config);
        }
    }
}
