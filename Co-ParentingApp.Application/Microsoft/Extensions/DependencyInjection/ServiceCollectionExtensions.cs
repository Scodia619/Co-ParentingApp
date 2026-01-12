using Co_ParentingApp.Application.Member;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Application.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApplication(this IServiceCollection services) =>
        services
            .AddMembers();

    public static IServiceCollection AddMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMemberService, MemberService>();
    }
}