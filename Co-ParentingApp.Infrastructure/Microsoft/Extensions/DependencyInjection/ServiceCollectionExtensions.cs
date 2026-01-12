using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Infrastructure.Member;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Infrastructure.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppInfrastructure(this IServiceCollection services) =>
        services
            .AddMembers();

    public static IServiceCollection AddMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMemberRepository, MemberRepository>();
    }
}
