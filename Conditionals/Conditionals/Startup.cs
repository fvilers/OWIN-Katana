using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System;
using System.Diagnostics;

namespace Conditionals
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/mic", nestedApp => nestedApp.Run(context => context.Response.WriteAsync("Hello, Microsoft Innovation Center!\r\n")));

            app.Use(StopwatchMiddleware);

            app.Run(context => context.Response.WriteAsync("Hello, World!\r\n"));
        }

        private static async Task StopwatchMiddleware(IOwinContext context, Func<Task> next)
        {
            var sw = new Stopwatch();
            sw.Start();

            await next.Invoke();
            sw.Stop();

            await context.Response.WriteAsync(String.Format("The pipeline execution took {0} ms\r\n", sw.ElapsedMilliseconds));
        }
    }
}
