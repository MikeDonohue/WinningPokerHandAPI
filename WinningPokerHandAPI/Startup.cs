using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poker.API.DbContexts;
using Poker.API.Repositories;
using Poker.API.Services;
using System.Reflection;
using System.IO;

namespace Poker.API
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
            services.AddControllers();

            //scans for classes that inherit from profile. Pass in the assembles so it knows where to look.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            services.AddScoped<IPokerHandsService, PokerHandsService>();

            services.AddScoped<IPokerHandsRepository, PokerHandsRepository>();

            //why is this automatically registered with a scoped lifetime.
            //ensures the db context is disposed of after everyrequest.
            //replaces our old fasioned using statement in .net framework
            //since this is used by our repositories they have to be registered with a
            //context that is equal to or shorter than the db context scope
            services.AddDbContext<PokerHandsContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=PokerDB;Trusted_Connection=True;");
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "PokerAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Poker API",
                        Version = "1.0",
                        Description = "API that accepts requests containing poker hands, compares their hand strength and returns the winner.",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "mdonohue256@gmail.com",
                            Name = "Michael Donohue",
                            Url = new Uri("https://www.linkedin.com/in/michael-donohue/")
                        }
                    });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlCommentsFile));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //putting after UseHttpsRedirection ensures any call to a non-encryted open api endpoint will be redirected to the encrypted version.
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/PokerAPISpecification/swagger.json", "Poker API");
                setupAction.RoutePrefix = "";
            });

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
