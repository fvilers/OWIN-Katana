using Microsoft.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Middlewares
{
    public class SetUserMiddleWare
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public SetUserMiddleWare(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);

            using (var reader = new StreamReader(context.Request.Body))
            {
                var json = await reader.ReadToEndAsync();
                var user = JsonConvert.DeserializeObject<User>(json);
                var identity = new GenericIdentity(user.Name);

                context.Request.User = new GenericPrincipal(identity, new[] { "echo" });
            }

            await _next(environment);
        }
    }

    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}