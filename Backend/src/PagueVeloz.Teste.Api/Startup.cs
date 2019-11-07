using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PagueVeloz.Teste.Infra.CrossCutting.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace PagueVeloz.Teste.Api
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

            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1.0", new Info
            //    {
            //        Version = "v1.0",
            //        Title = "Api para teste na PagueVeloz",
            //        Description = "PagueVeloz Teste Api",
            //    });
            //});

            services.AddMediatR(typeof(Startup));
            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1.0/swagger.json", "API REST v1.0"); });
            //app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
