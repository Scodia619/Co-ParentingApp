using Co_ParentingApp.Data.Models.RequestModels.Conversation;

namespace Co_ParentingApp.Application.Conversation;

public interface IConversationService
{
    Task<IReadOnlyCollection<ConversationsReturnModel>> GetConversationsByMemberIdAsync(Guid memberId);
}