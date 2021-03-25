using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Appointment.API.Contexts;
using Appointment.API.Data;
using AutoMapper;
using System;
using Appointment.API.Data.Contracts;
using WebApi.Helpers;
using WebApi.Services;

namespace Appointment.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddCors();
            services.AddDbContext<Context>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionDatabase")));
            services.AddControllers();
            services.AddMvc()
                .AddMvcOptions(o =>
                {
                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<ISecurityService, SecurityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
