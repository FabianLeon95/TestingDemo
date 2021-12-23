using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingDemo.Domain.Interfaces.Repositories;
using TestingDemo.Infrastructure.DataContexts;
using TestingDemo.Infrastructure.Repositories;

namespace TestingDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                    builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            return services;
        }
    }
}
