using AspNetCore3._1Student.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configureationProvider)
        {
            _configuration = configureationProvider;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SqlDbContext>(builder =>
              builder.UseSqlServer(_configuration.GetConnectionString("StudentDBConnection"))
            );
            services.AddDbContextPool<SqlAdminContext>(builder =>
              builder.UseSqlServer(_configuration.GetConnectionString("AdminDbConnection"))
            );
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IStudentRepository,SqlStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();//¾²Ì¬ÎÄ¼þ

            app.UseSession();

            //app.UseRouting();
            app.UseMvc(route => route.MapRoute("default", "{controller=Home}/{action=Admin}/{id?}"));
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
