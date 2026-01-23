using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.AspNetCore.SignalR;

namespace Co_ParentingApp.API.Hubs;

public class ChatHub : Hub
{
    public async Task JoinConversation(string conversationId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
    }

    public async Task SendMessage(string conversationId, MessageEntity message)
    {
        await Clients.Group(conversationId)
            .SendAsync("ReceiveMessage", message);
    }
}
