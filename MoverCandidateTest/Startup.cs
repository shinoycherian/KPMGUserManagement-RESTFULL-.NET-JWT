using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mover.CandidateTest.BusinessObjects;
using Mover.CandidateTest.Application.Services;
using Mover.CandidateTest.Application;
namespace MoverCandidateTest
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
            //Adding Automapper to map Model to ViewModel.  

            services.AddApplicationLayer();
            //Configure repository (done in Datalayer with Factory approach,)
            //Configure BusinessObjects.
            services.AddScoped<IProductBusinessObject, ProductBusinessObject>();
            //Configure Product Service.
            services.AddScoped<IProductService, ProductService>();
            //Configure WatchHands Service.
            services.AddScoped<IWatchService, WatchService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
