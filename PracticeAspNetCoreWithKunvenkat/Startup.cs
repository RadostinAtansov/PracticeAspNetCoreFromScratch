namespace PracticeAspNetCoreWithKunvenkat
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using PracticeAspNetCoreWithKunvenkat.Models;
    using PracticeAspNetCoreWithKunvenkat.Security;
    using System;
    using System.Configuration;

    public class Startup
    {
        private IConfiguration _config;
        private IConfigurationRoot Configuration;

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
                option.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContex>();

            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = "1043436038570-kj3b3vpjsn5ebg9qalp95v471fq048fb.apps.googleusercontent.com";
                        options.ClientSecret = "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";
                    });

            services.ConfigureApplicationCookie(options =>
            { 
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));

                option.AddPolicy("EditRolePolicy",
                        policy => policy.AddRequirements(new ManageAdminRoleAndClaimsRequirement()));
                
                option.AddPolicy("AdminRolePolicy",
                     policy => policy.RequireRole("Admin"));
            });
            
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeReository>();
            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {

            var builder = new ConfigurationBuilder()                                    //
                .SetBasePath(env.ContentRootPath)                                       // ==> add connection string                                                                    to windows variable (secrets.json)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);//

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

            }

            builder.AddEnvironmentVariables();  // add to secrets.json
            Configuration = builder.Build();    //

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
