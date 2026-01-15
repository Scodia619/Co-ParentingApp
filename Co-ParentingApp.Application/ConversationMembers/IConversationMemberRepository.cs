using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.ConversationMembers;

public interface IConversationMemberRepository
{
    Task<ConversationMembersEntity> CreateConversationMembersAsync(ConversationMembersEntity conversationMembers);
    Task<ConversationMembersEntity?> GetConversationMembersByMemberIdAndConversationId(Guid memberId, Guid conversationId);
}