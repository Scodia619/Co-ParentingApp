using Co_ParentingApp.API.Mappers.Message;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Infrastructure.Member;

namespace Co_ParentingApp.API.Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoParentingAppApi(this IServiceCollection services) =>
        services
            .AddConversation();

    public static IServiceCollection AddConversation(this IServiceCollection services)
    {
        return services
            .AddTransient<IMessageControllerMapper, MessageControllerMapper>();
    }
}