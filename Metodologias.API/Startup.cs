using Metodologias.BLL.Services;
using Metodologias.DAL;
using Metodologias.DAL.Repositories;
using Metodologias.Infrastracture.Interfaces.Repositories;
using Metodologias.Infrastracture.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace Metodologias.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(opt => opt.UseInMemoryDatabase("InMem"));

            //Services
            services.AddScoped<ISignalService, SignalsService>();

            //Repositories
            services.AddScoped<ISinalRepository, SinalsRepository>();

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Metodologias.API", Version = "v1" });
            });


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AddValues.AddValuesToMemory(app);
        }
    }
}
