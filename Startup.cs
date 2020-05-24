using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Codacious.GraphQL.AutoMapper;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;
using Codacious.GraphQL.GraphQL;
using Codacious.GraphQL.Models;
using Codacious.GraphQL.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Codacious.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<HotelDbContext>(options =>  options.UseSqlServer(HotelDbContext.DbConnectionString));
            services.AddTransient<ReservationRepository>();
            services.AddTransient<RoomRepository>();
            services.AddTransient<GuestRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfile(new HotelProfile());
            });

            services.AddSingleton(mapperConfiguration);


            services.AddSingleton<IMapper>(_ => mapperConfiguration.CreateMapper());

            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<HotelSchema>();

            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            })
            .AddGraphTypes(ServiceLifetime.Scoped);

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            app.UseGraphQL<HotelSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground           //... UseMVC ....

        }
    }
}
