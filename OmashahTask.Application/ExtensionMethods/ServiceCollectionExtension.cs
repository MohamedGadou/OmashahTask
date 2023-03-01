using Microsoft.Extensions.DependencyInjection;
using OmashahTask.Application.IServices;
using OmashahTask.Application.Services;
using OmashahTask.Domain.IRepos;
using OmashahTask.Infrastructure;
using OmashahTask.Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Application.ExtensionMethods
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            DbContextRegisterer.RegisterDbContext(services, connectionString);
        }

        public static void RegisterRepos(this IServiceCollection services)
        {
            services.AddScoped<IItemRepo, ItemRepo>();
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IItemAppService, ItemAppService>();
        }
    }
}
