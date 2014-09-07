using Owin;

namespace Chaining
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context => context.Response.WriteAsync("I'm middleware #1"));
            app.Run(context => context.Response.WriteAsync("I'm middleware #2"));
        }
    }
}
