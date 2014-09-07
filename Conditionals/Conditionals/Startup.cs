using System;
using System.Diagnostics;
using Owin;

namespace Conditionals
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/mic", nestedApp =>
            {
                nestedApp.Use(async (context, next) =>
                {
                    var sw = new Stopwatch();
                    sw.Start();

                    await next.Invoke();
                    sw.Stop();

                    await context.Response.WriteAsync(String.Format("The pipeline execution took {0} ms\r\n", sw.ElapsedMilliseconds));
                });

                nestedApp.Run(context => context.Response.WriteAsync("Hello, Microsoft Innovation Center!\r\n"));
            });

            app.Run(context => context.Response.WriteAsync("Hello, World!\r\n"));
        }
    }
}
