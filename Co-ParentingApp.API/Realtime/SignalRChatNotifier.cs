using Co_ParentingApp.API.Hubs;
using Co_ParentingApp.Application.Realtime;
using Co_ParentingApp.Data.Models.Records;
using Microsoft.AspNetCore.SignalR;

namespace Co_ParentingApp.API.Realtime;

public class SignalRChatNotifier : IChatNotifier
{
    private readonly IHubContext<ChatHub> _hubContext;

    public SignalRChatNotifier(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task MessageSentAsync(Guid conversationId, MessageRecord message)
    {
        await _hubContext.Clients
            .Group(conversationId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}
