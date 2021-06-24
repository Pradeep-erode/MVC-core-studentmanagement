using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Studentmanagement.Core.IRepository;
using Studentmanagement.Core.IService;
using Studentmanagement.Resource.Repository;
using Studentmanagement.Service;
using System;

namespace Studentmanagement.Utility
{
    public static class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for database accessing process below line should used
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddScoped<IServices, Serviceclass>();
            #endregion

            #region Services

            services.AddScoped<IRepository, Repository>();

            #endregion
    

        }
    }
}
