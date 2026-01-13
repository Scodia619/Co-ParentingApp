using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Infrastructure.MatchedMembers;
using Co_ParentingApp.Infrastructure.Member;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Infrastructure.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppInfrastructure(this IServiceCollection services) =>
        services
            .AddMembers()
            .AddMatchedMembers();

    public static IServiceCollection AddMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMemberRepository, MemberRepository>();
    }

    public static IServiceCollection AddMatchedMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMatchedMembersRepository, MatchedMembersRepository>();
    }
}
