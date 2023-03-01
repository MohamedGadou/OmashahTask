using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OmashahTask.Infrastructure.DBContext;


namespace OmashahTask.Infrastructure
{
    public static class DbContextRegisterer
    {
        public static void RegisterDbContext(IServiceCollection services, string connectionString)
        {

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'OmashahTaskContext' not found.");

            services.AddDbContext<OmashahTaskDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
