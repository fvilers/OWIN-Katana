using Microsoft.Owin;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CompleteSample.Logging
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            Console.Write("{0} {1}", context.Request.Method, context.Request.Path);

            await Next.Invoke(context);
            sw.Stop();

            Console.WriteLine(" ({0} ms)", sw.ElapsedMilliseconds);
        }
    }
}
