using Owin;
using System.Text;

namespace HelloWorld
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                var response = context.Response;
                var bytes = Encoding.UTF8.GetBytes("<html><body><h1>Hello, world!</h1></body></html>");

                response.ContentLength = bytes.Length;
                response.ContentType = "text/html";

                return response.WriteAsync(bytes);
            });
        }
    }
}
