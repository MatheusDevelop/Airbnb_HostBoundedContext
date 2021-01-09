using System.Reflection;
using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.Extensions.Options;
using Domain.Services;
using Domain.Services.Implementations;
using System;
using Domain.Commands.Request;
using Domain.Handlers;
using Domain.Commands.Result;

namespace Presentation
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

            services.AddSingleton<IFurnitureRepository, FurnitureRepository>();
            services.AddSingleton<IAcommodationRepository,AcommodationRepository>();
            services.AddTransient<IPaymentService, PaymentService>();

            services.AddScoped<IRequestHandler<FurnitureReservationRequest, FurnitureReservationResult>, FurnitureReservationHandler>();

            services.AddMediatR(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson();
            
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
        }
    }
}
