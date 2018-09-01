using System;
using System.Collections.Generic;
using System.Linq;
using Data.DataContext;
using LeaderboardCoreAPI.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaderboardCoreAPI
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
            services.AddMvc();

            //var connection = Configuration.GetConnectionString("LeaderboardDatabase");

            //services.AddDbContext<LeaderboardContext>(options =>
            //    options.UseSqlServer(connection)
            //    .EnableSensitiveDataLogging());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var username = Configuration.GetSection("Authentication").GetValue<string>("username");
            var password = Configuration.GetSection("Authentication").GetValue<string>("password");
            app.UseMiddleware<AuthenticationMiddleware>(username, password);

            app.UseMvc();
        }
    }
}
