﻿using Owin;

namespace Middlewares
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<SetUserMiddleWare>();
            app.Use<EchoBodyMiddleWare>();
        }
    }
}
