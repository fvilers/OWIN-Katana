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
            await BufferRequestStreamAsync(context.Request);

            // reader is not disposed to ensure the stream will be available for other middlewares
            var reader = new StreamReader(context.Request.Body);
            var json = await reader.ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<User>(json);
            var identity = new GenericIdentity(user.Name);

            context.Request.User = new GenericPrincipal(identity, new[] { "echo" });
            context.Request.Body.Seek(0L, SeekOrigin.Begin);

            await _next(environment);
        }

        private static async Task BufferRequestStreamAsync(IOwinRequest request)
        {
            var requestStream = new MemoryStream();

            await request.Body.CopyToAsync(requestStream);
            requestStream.Seek(0L, SeekOrigin.Begin);
            request.Body = requestStream;
        }
    }

    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}