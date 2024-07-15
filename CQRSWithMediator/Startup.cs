using HealthcareInsurance.Infrastructure.Implementation;
using HealthcareInsurance.Infrastructure.Interfaces;
using HealthcareInsurance.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using HealthcareInsurance.Application.Handlers;
using MediatR;
using HealthcareInsurance.Application.Validators;
using FluentValidation;

namespace HealthcareInsurance.API
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services, including DbContext, authentication, MVC, etc.

            // Add services to the container.

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddMediatR(typeof(CreatePatientCommandHandler).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreatePatientCommandValidator).Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthcareInsurance API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthcareInsurance API");
                    c.RoutePrefix = "swagger";
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // Enable authentication middleware
            app.UseAuthentication();            

            // Middleware for routing
            app.UseRouting();

            // Enable authorization middleware (if needed)
            app.UseAuthorization();

            // Endpoint middleware for MapControllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Final middleware or handler
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from the end of the pipeline!");
            });
        }
    }
}
