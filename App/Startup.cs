﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace App
{
    public class Startup
    {

        public static IConfigurationRoot Configuration;
        //public Startup(IApplicationEnvironment appEnv)
        //{
        //    var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
        //        .AddJsonFile("config.json")
        //        .AddEnvironmentVariables();

        //    Configuration = builder.Build();
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //if (env.IsDevelopment())
            //{
            //    //Just for mail Service testing purpose
            //    services.AddScoped<IMailService, DebugMailService>();
            //}
            //else
            //{
            //    //real mail service implementation
            //    services.AddScoped<IMailService, RealMailService>();
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" } 
                );
            });
            //app.UseIISPlatformHandler();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
