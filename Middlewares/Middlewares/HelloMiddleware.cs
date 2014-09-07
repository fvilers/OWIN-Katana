using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class HelloMiddleware
    {
        private readonly AppFunc _next;
        private readonly GreetingOptions _options;

        public HelloMiddleware(AppFunc next, GreetingOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            var response = context.Response;
            byte[] bytes;

            if (_options.IsHtml)
            {
                bytes = Encoding.UTF8.GetBytes(String.Format("<html><body>{0}</body></html>", _options.Message));

                response.ContentLength = bytes.Length;
                response.ContentType = "text/html";
            }
            else
            {
                bytes = Encoding.UTF8.GetBytes(_options.Message);
            }

            await response.WriteAsync(bytes);
            await _next(environment);
        }
    }

    public class GreetingOptions
    {
        public string Message { get; set; }
        public bool IsHtml { get; set; }
    }
}