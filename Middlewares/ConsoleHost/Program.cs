﻿using Microsoft.Owin.Hosting;
using Middlewares;
using Middlewares.Controllers;
using System;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // This ensures that the Middlewares assembly gets loaded
            var controllerType = typeof(ProductController);

            const string url = "http://localhost:5000";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Host is listening on {0}... Press any key to quit.", url);
                Console.ReadLine();
            }
        }
    }
}
