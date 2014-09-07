using Owin;

namespace Chaining
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                context.Response.WriteAsync("I'm middleware #1");

                return next.Invoke();
            });

            app.Run(context => context.Response.WriteAsync(" - I'm middleware #2"));
        }
    }
}
