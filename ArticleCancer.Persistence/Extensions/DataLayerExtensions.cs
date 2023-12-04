using ArticleCancer.Application.Interfaces.Repositories;
using ArticleCancer.Persistence.Context;
using ArticleCancer.Persistence.Repositories;
using ArticleCancer.Persistence.UnıtOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleCancer.Persistence.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnıtOfWork, UnitOfWork>();

            return services;


        }
    }
}
