using Microsoft.Owin;
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

            await Next.Invoke(context);
            sw.Stop();

            // TODO: Log the request and its execution time
        }
    }
}
