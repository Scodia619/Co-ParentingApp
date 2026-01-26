using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.RequestModels.Conversation;

namespace Co_ParentingApp.Application.Conversation;

public class ConversationMapper : IConversationMapper
{
    public ConversationsReturnModel ToReturnModel(ConversationReturnEntity entity)
    {
        return new ConversationsReturnModel
        {
            ConversationId = entity.ConversationId,
            ParticipantId = entity.ParticipantId,
            ParticipantName = entity.ParticipantName,
            LastMessage = entity.LastMessage,
            LastMessageAt = entity.LastMessageAt,
            UnreadCount = entity.UnreadCount
        };
    }

    public IReadOnlyCollection<ConversationsReturnModel> ToReturnModels(IEnumerable<ConversationReturnEntity> entities)
    {
        return entities.Select(ToReturnModel).ToList();
    }
}
