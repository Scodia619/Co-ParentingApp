using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Application.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApplication(this IServiceCollection services) =>
        services
            .AddMembers()
            .AddMatchedMembers();

    public static IServiceCollection AddMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMemberService, MemberService>();
    }

    public static IServiceCollection AddMatchedMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IMatchedMembersService, MatchedMembersService>()
            .AddTransient<IMatchedMemberMapper, MatchedMemberMapper>();
    }
}