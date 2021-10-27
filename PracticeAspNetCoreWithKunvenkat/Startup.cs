namespace PracticeAspNetCoreWithKunvenkat
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using PracticeAspNetCoreWithKunvenkat.Models;

    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>(); ;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // combine seDefauteFile and UseStaticFilese.
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(route =>
            //route.MapRoute("default", "{controller=Home}/{action=index}/{id?}"));

            app.UseMvc();
        }
    }
}
