using Middlewares.Controllers;
using Owin;
using System.Text;
using System.Web.Http;

namespace Middlewares
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(config);
            app.Run(async context =>
            {
                var response = context.Response;
                var bytes = Encoding.UTF8.GetBytes("<html><body><h1>Hello, world!</h1></body></html>");

                response.ContentLength = bytes.Length;
                response.ContentType = "text/html";

                await response.WriteAsync(bytes);
            });
        }
    }
}
