namespace PracticeAspNetCoreWithKunvenkat
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
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

            services.AddDbContextPool<AppDbContex>(options =>
            options.UseSqlServer(_config.GetConnectionString("EmployeeDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 10;
                option.Password.RequiredUniqueChars = 3;
            })
                .AddEntityFrameworkStores<AppDbContex>();

            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeReository>(); ;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

            }

            app.UseStatusCodePagesWithReExecute("/Error/{0}");  

            app.UseStaticFiles(); // combine seDefauteFile and UseStaticFilese.
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();


            app.UseMvc(route =>
            route.MapRoute("default", "{controller=home}/{action=index}/{id?}")); // without attribute


            //app.UseMvc(); only with attribute
        }
    }
}
