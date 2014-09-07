using Owin;

namespace Middlewares
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<RawMiddleware>();
            app.Use<HelloMiddleware>(new GreetingOptions { Message = "<h1>Hello, world!</h1>", IsHtml = true });
        }
    }
}
