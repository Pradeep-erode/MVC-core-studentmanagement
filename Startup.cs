using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Studentmanagement.Core;
using Studentmanagement.Core.IRepository;
using Studentmanagement.Core.IService;
using Studentmanagement.Resource;
using Studentmanagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studentmanagement.Core.Mystudent_class;
using Studentmanagement.Resource.Repository;
using Studentmanagement.Utility;

namespace sample_mvc8
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

            services.AddControllersWithViews();

            //for adding dependency injection we use specific folder
            //DIResolver.ConfigureServices(services);
            //also use like below
            //services.Add(new ServiceDescriptor(typeof(IServices), new Serviceclass()));
            //services.Add(new ServiceDescriptor(typeof(IRepository), new Repository()));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=APIHome}/{action=Index}/{id?}");
            });
        }
    }
}
