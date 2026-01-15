using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.Conversation;

public interface IConversationRepository
{
    Task<ConversationEntity> CreateConversationAsync(ConversationEntity conversation);
    Task UpdateLastMessageByConversationId(Guid conversationId, string content, DateTime time);
}

