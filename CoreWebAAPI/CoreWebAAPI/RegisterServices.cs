using CoreWebAAPI.IServices;
using CoreWebAAPI.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAAPI
{
    public static class RegisterServices 
    {
        public static void RegisterConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = Environment.GetEnvironmentVariable("PostGreSqlConnection");
            services.AddDbContext<SampleDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Singleton);

            services.AddSingleton<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IProjectService, ProjectService>();
        }
    }
}
