using AutoMapper;
using LastTask.BL.Interface;
using LastTask.BL.Services;
using LastTask.DL.Interface;
using LastTask.DL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.DL.InMemoryDB;

namespace LastTask
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
            InMemoryDb.Init();

            services.AddControllers();

            services.AddSingleton<IComputerRepository, ComputerRepository>();
            services.AddSingleton<ILaptopRepository, LaptopRepository>();
            services.AddSingleton<ISmartphoneRepository, SmartphoneRepository>();
            services.AddSingleton<ITelevisorRepository, TelevisorRepository>();

            services.AddSingleton<IComputerService, ComputerService>();
            services.AddSingleton<ILaptopService, LaptopService>();
            services.AddSingleton<ISmartphoneService, SmartphoneService>();
            services.AddSingleton<ITelevisorService, TelevisorService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "LastTask",
                        Description = "Project",
                        Version = "v1"
                    });
            });

            services.AddHealthChecks();

            services.AddAutoMapper(typeof(Startup));
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
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "LASTTASK");
            });
        }
    }
}
