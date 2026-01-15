using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.ConversationMembers;

public interface IConversationMemberMapper
{
    ConversationMembersEntity MapToEntity(Guid conversationId, Guid memberId);
}