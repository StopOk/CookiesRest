using CookiesRest.Application.Common.Authentication;
using CookiesRest.Application.Common.Interfaces.Persistence;
using CookiesRest.Application.Common.Interfaces.Services;
using CookiesRest.Infrastructure.Authentication;
using CookiesRest.Infrastructure.Persistence;
using CookiesRest.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookiesRest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfruastruture(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGen, JwtTokenGen>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepo, UserRepo>();
        
        return services;
    }
}