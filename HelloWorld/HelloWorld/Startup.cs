using Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var middleware = new Func<AppFunc, AppFunc>(CreateMiddleware);

            app.Use(middleware);
        }

        private static AppFunc CreateMiddleware(AppFunc next)
        {
            AppFunc middleware = environment =>
            {
                var response = (Stream)environment["owin.ResponseBody"];
                var bytes = Encoding.UTF8.GetBytes("<html><body><h1>Hello, world!</h1></body></html>");
                var headers = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

                headers["Content-Length"] = new[] { bytes.Length.ToString(CultureInfo.InvariantCulture) };
                headers["Content-Type"] = new[] { "text/html" };
                response.WriteAsync(bytes, 0, bytes.Length);

                return next(environment);
            };

            return middleware;
        }
    }
}
