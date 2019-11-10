using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PagueVeloz.Teste.Infra.CrossCutting.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace PagueVeloz.Teste.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddJsonFile($"appsettings.Development.json", true);
            }
            if (env.IsStaging())
            {
                builder.AddJsonFile($"appsettings.Staging.json", true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1.0", new Info
                {
                    Version = "v1.0",
                    Title = "Api para teste na PagueVeloz",
                    Description = "PagueVeloz Teste Api",
                });
            });

            services.AddMediatR(typeof(Startup));
            RegisterServices(services);
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
                app.UseHsts();
            }

            //app.UseCors(c =>
            //{
            //    c.AllowAnyHeader();
            //    c.AllowAnyMethod();
            //    c.AllowAnyOrigin();
            //});

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1.0/swagger.json", "API REST v1.0"); });
            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
