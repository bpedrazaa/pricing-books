using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Serilog;

using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Managers;
using UPB.PricingBooks.Presentation.Middlewares;
using UPB.PricingBooks.Services;

namespace PricingBooks
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            //Serilog Configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .WriteTo.File(Configuration.GetSection("Project").GetSection("LogPath").Value)
                .CreateLogger();
            Log.Information($"In environment: {env.EnvironmentName}");
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDbContext, DbContext>();
            services.AddTransient<IProductsManager, ProductsManager>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<IPricingBooksManager, PricingBooksManager>();
            services.AddControllers();

            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v3", new OpenApiInfo { Title = "Pricing Books", Version = "v3" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGlobalExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/swagger/v3/swagger.json", "Pricing Books");
            });

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
