using Owin;

namespace Conditionals
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/mic", nestedApp =>
            {
                nestedApp.Map("/renaud", renaudApp => renaudApp.Run(context => context.Response.WriteAsync("Hello, Renaud!")));

                nestedApp.Run(context => context.Response.WriteAsync("Hello, Microsoft Innovation Center!\r\n"));
            });

            app.Run(context => context.Response.WriteAsync("Hello, World!\r\n"));
        }
    }
}
