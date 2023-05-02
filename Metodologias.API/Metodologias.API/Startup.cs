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

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();

                builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddDbContext<ApplicationDBContext>(opt => opt.UseInMemoryDatabase("InMem"));
            services.AddControllers();
            services.AddSignalR();
            services.AddHttpContextAccessor();

            //Services
            services.AddTransient<ISignalService, SignalsService>();

            //Repositories
            services.AddTransient<ISinalRepository, SinalsRepository>();


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

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                await next();
                var path = context.Request.Path.Value;

                //Se o path estiver vazio ou for para ver o index.html
                //E se não for para obter a API, o swagger ou algum outro ficheiro
                if (path == null || path == "/index.html" || (!path.StartsWith("/api") && !Path.HasExtension(path) && !path.StartsWith("/swagger") && !path.StartsWith("/notificationHub")))
                {
                    //Redirecionamos para o HTML
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            AddValues.AddValuesToMemory(app);
        }
    }
}
