using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Application.Message;
using Co_ParentingApp.Infrastructure.Conversation;
using Co_ParentingApp.Infrastructure.ConversationMembers;
using Co_ParentingApp.Infrastructure.MatchedMembers;
using Co_ParentingApp.Infrastructure.Member;
using Co_ParentingApp.Infrastructure.Message;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Infrastructure.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppInfrastructure(this IServiceCollection services) =>
        services
            .AddConversation()
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
    public static IServiceCollection AddConversation(this IServiceCollection services)
    {
        return services
            .AddTransient<IConversationRepository, ConversationRepository>()
            .AddTransient<IConversationMemberRepository, ConversationMembersRepository>()
            .AddTransient<IMessageRepository, MessageRepository>();
    }
}
