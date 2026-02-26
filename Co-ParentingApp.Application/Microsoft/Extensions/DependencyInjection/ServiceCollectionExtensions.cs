using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Application.Message;
using Co_ParentingApp.Application.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Co_ParentingApp.Application.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApplication(this IServiceCollection services) =>
        services
            .AddConversations()
            .AddConversationMembers()
            .AddMember()
            .AddMatchedMember()
            .AddRedis();

    public static IServiceCollection AddMember(this IServiceCollection services)
    {
        return services
            .AddTransient<IMemberService, MemberService>();
    }

    public static IServiceCollection AddMatchedMember(this IServiceCollection services)
    {
        return services
            .AddTransient<IMatchedMembersService, MatchedMembersService>()
            .AddTransient<IMatchedMemberMapper, MatchedMemberMapper>();
    }

    public static IServiceCollection AddConversations(this IServiceCollection services)
    {
        return services
            .AddTransient<IConversationService, ConversationService>()
            .AddTransient<IConversationMapper, ConversationMapper>()
            .AddTransient<IMessageService, MessageService>()
            .AddTransient<IMessageMapper, MessageMapper>();
    }

    public static IServiceCollection AddConversationMembers(this IServiceCollection services)
    {
        return services
            .AddTransient<IConversationMemberMapper, ConversationMemberMapper>()
            .AddTransient<IConversationMemberService, ConversationMemberService>();
    }

    public static IServiceCollection AddRedis(this IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = services.BuildServiceProvider()
                                            .GetRequiredService<IConfiguration>()["Redis:ConnectionString"];
        });

        services.AddTransient<IRedisService, RedisService>();

        return services;
    }
}