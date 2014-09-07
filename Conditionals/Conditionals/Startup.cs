using Owin;
using System;
using System.Linq;

namespace Conditionals
{
    public class Startup
    {
        private static readonly string[] PeopleFromMic = { "Martine", "Renaud", "Thomas", "Xavier" };

        public void Configuration(IAppBuilder app)
        {
            app.Map("/mic", micApp =>
            {
                micApp.MapWhen(context =>
                {
                    if (context.Request.Path.HasValue)
                    {
                        var name = context.Request.Path.Value.Trim('/');
                        return PeopleFromMic.Any(item => StringComparer.InvariantCultureIgnoreCase.Equals(name, item));
                    }

                    return false;
                },
                micPeopleApp => micPeopleApp.Run(context =>
                {
                    var name = context.Request.Path.Value.Trim('/');
                    return context.Response.WriteAsync(String.Format("Hello, {0}\r\n", name));
                }));

                micApp.Run(context => context.Response.WriteAsync("Hello, Microsoft Innovation Center!\r\n"));
            });

            app.Run(context => context.Response.WriteAsync("Hello, World!\r\n"));
        }
    }
}
