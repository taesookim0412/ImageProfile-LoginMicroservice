using ImageProfile_Login.Models;
using ImageProfile_Login.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProfile_Login
{
    public class Startup
    {
        IWebHostEnvironment _env = null;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddRazorPages();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "apps/ImageProfile/build";
            });
            
            if (_env.IsDevelopment())
            {
                string connectionStringReader = Configuration.GetConnectionString("ImageProfileDevReader");
                services.AddDbContext<UserReader>(options => options.UseMySql(connectionStringReader, ServerVersion.AutoDetect(connectionStringReader)));
                string connectionStringWriter = Configuration.GetConnectionString("ImageProfileDevWriter");
                services.AddDbContext<UserWriter>(options => options.UseMySql(connectionStringWriter, ServerVersion.AutoDetect(connectionStringWriter)));
            }
            else
            {
                string connectionStringReader = Configuration.GetConnectionString("ImageProfileProdReader");
                services.AddDbContext<UserReader>(options => options.UseMySql(connectionStringReader, ServerVersion.AutoDetect(connectionStringReader)));
                string connectionStringWriter = Configuration.GetConnectionString("ImageProfileProdWriter");
                services.AddDbContext<UserWriter>(options => options.UseMySql(connectionStringWriter, ServerVersion.AutoDetect(connectionStringWriter)));
            }
            
            services.AddTransient<UserRepository>();

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
                app.UseExceptionHandler("/Error");
            }

            //app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            // breaks production if specifying paths in HttpGet/Post (when using UseSpa). So controllers must be reflective by method name, not direct paths.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                //dont use this, handle the proxy through spa's package json and route requests to :5000
                //spa.UseProxyToSpaDevelopmentServer("http://localhost:8000/");
                spa.Options.SourcePath = "apps/ImageProfile";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

        }
    }
}
