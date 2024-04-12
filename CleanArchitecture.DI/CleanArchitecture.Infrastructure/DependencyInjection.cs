using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieRentalDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(MovieRentalDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IMovieRentalDBContext>(provider => provider.GetService<MovieRentalDBContext>());

            return services;
        }
    }
}
    