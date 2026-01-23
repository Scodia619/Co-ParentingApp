using Co_ParentingApp.Data.Models.Records;

namespace Co_ParentingApp.Application.Realtime;

public interface IChatNotifier
{
    Task MessageSentAsync(Guid conversationId, MessageRecord message);
}
