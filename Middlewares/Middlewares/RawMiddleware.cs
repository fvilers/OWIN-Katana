using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class RawMiddleware
    {
        private readonly AppFunc _next;

        public RawMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var headers = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

            headers["X-Generated-By"] = new[] { "RawMiddleware" };

            await _next(environment);
        }
    }
}