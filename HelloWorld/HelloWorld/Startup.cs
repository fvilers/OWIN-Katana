using Owin;
using System;
using System.Collections.Generic;
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
                var bytes = Encoding.UTF8.GetBytes("Hello, world!");

                response.WriteAsync(bytes, 0, bytes.Length);

                return next(environment);
            };

            return middleware;
        }
    }
}
