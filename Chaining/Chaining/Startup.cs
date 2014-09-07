using Owin;
using System;
using System.Diagnostics;
using System.Threading;

namespace Chaining
{
    public class Startup
    {
        private static readonly Random Randomizer = new Random();

        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var sw = new Stopwatch();
                sw.Start();

                await next.Invoke();
                sw.Stop();

                await context.Response.WriteAsync(String.Format("The pipeline execution took {0} ms\r\n", sw.ElapsedMilliseconds));
            });

            app.Use((context, next) =>
            {
                context.Response.WriteAsync("I'm middleware #1\r\n");
                Thread.Sleep(Randomizer.Next(500));

                return next.Invoke();
            });

            app.Use((context, next) =>
            {
                context.Response.WriteAsync("I'm middleware #2\r\n");
                Thread.Sleep(Randomizer.Next(1000));

                return next.Invoke();
            });
        }
    }
}
