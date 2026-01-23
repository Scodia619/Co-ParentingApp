using Co_ParentingApp.API.Mappers.Message;
using Co_ParentingApp.API.Realtime;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Application.Realtime;
using Co_ParentingApp.Infrastructure.Member;

namespace Co_ParentingApp.API.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApi(this IServiceCollection services) =>
        services
            .AddConversation()
            .AddRealtime();

    public static IServiceCollection AddConversation(this IServiceCollection services)
    {
        return services
            .AddTransient<IMessageControllerMapper, MessageControllerMapper>();
    }

    public static IServiceCollection AddRealtime(this IServiceCollection services)
    {
        return services
            .AddTransient<IChatNotifier, SignalRChatNotifier>();
    }
}