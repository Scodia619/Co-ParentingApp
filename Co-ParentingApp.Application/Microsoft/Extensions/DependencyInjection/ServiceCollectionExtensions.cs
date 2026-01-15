using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Application.Message;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Application.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApplication(this IServiceCollection services) =>
        services
            .AddConversation()
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

    public static IServiceCollection AddConversation(this IServiceCollection services)
    {
        return services
            .AddTransient<IConversationMemberMapper, ConversationMemberMapper>()
            .AddTransient<IMessageService, MessageService>()
            .AddTransient<IMessageMapper, MessageMapper>();
    }
}