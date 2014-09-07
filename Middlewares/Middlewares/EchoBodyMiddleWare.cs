using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class EchoBodyMiddleWare
    {
        private readonly AppFunc _next;

        public EchoBodyMiddleWare(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);

            if (context.Request.Method == "POST")
            {
                var response = context.Response;

                using (var reader = new StreamReader(context.Request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    var bytes = Encoding.UTF8.GetBytes(body);

                    response.ContentLength = bytes.Length;
                    await response.WriteAsync(bytes);
                }
            }

            await _next(environment);
        }
    }
}