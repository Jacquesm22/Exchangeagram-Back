using ExchangeAGram.Application.Common.Interfaces;
using ExchangeAGram.Application.Common.Models;
using ExchangeAGram.Infrastructure.Persistence;
using ExchangeAGram.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeAGram.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddSingleton<IJwtTokenBuilder, JwtTokenBuilderService>();
            services.AddSingleton<IHashService, BasicHashService>();

            services.Configure<AuthenticationSettings>(configuration.GetSection("Authentication"));

            return services;
        }
    }
}
