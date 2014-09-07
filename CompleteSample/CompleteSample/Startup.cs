using CompleteSample.Authentication;
using CompleteSample.Logging;
using Owin;

namespace CompleteSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<LoggingMiddleware>();
            app.Use<AuthenticationMiddleware>();
        }
    }
}
