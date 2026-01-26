using Co_ParentingApp.Data.Models.DTO;

namespace Co_ParentingApp.Application.ConversationMembers;
public interface IConversationMemberService
{
    Task<int> GetUnreadMessageCountAllConversationsAsync(Guid memberId);
    Task<List<ConversationUnreadDto>> GetUnreadMessagesPerConversationAsync(Guid memberId);
    Task MarkConversationAsReadAsync(Guid memberId, Guid conversationId);
}
