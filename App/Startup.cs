﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using TheWorld.ModelView;
using TheWorld.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Authentication.Cookies;

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
            services.AddMvc()
                .AddJsonOptions(opt =>
                    { opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); }
                    );
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>();
            services.AddIdentity<WorldUser, IdentityRole>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 8;
                }
            ).AddEntityFrameworkStores<WorldContext>();

           

            //services.ConfigureCookieAuthentication(config = > 
            //{
            //    config.LoginPath = "/Auth/Login";
            //});

            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<CoodinateServiceResult>(); //adding the cordicate service
            services.AddScoped<IWorldRepository, WorldRepository>();
            services.AddLogging(); // adding the functionility of the debugging and logging
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
        public async void Configure(IApplicationBuilder app, WorldContextSeedData seeder,ILoggerFactory logFactory)
        {
            logFactory.AddDebug(LogLevel.Information);
            app.UseStaticFiles();
            app.UseIdentity();

            Mapper.Initialize(conf =>
                {
                    conf.CreateMap<Trip, TripModelView>().ReverseMap();
                    conf.CreateMap<Stop, StopModelView>().ReverseMap();
                 }  //createMap<src,dest>();
            );

            app.UseCookieAuthentication(opt =>
            {
               
                opt.LoginPath = new PathString("/Account/Login");
                
                    
            });

            
        app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" } 
                );
            });

           await seeder.EnsureDataWithAsync();

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
