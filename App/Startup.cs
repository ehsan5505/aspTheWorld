﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;

namespace App
{
    public class Startup
    {
        
        //public static IConfigurationRoot Configuration;
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
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>();
            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<IWorldRepository, WorldRepository>();
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
        public void Configure(IApplicationBuilder app, WorldContextSeedData seeder)
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

            seeder.EnsureData();

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