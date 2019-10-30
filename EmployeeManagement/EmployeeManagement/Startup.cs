using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement
{
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
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddMvc().AddXmlSerializerFormatters();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // void Configure method is use to set up a request processing pipeline for the application
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //MVC malware
            app.UseStaticFiles();           // malware for image,css,js
            //app.UseMvc();


            
            //app.UseMvcWithDefaultRoute();                       // support the application request processing pipeline with a default route
            // same as app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);      //will display process name that hosting and running asp.net which is issexpress

            });
        }
    }
}
