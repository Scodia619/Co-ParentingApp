using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.ConversationMembers;

internal class ConversationMemberMapper : IConversationMemberMapper
{
    public ConversationMembersEntity MapToEntity(Guid conversationId, Guid memberId)
    {
        return new ConversationMembersEntity
        {
            ConversationId = conversationId,
            MemberId = memberId
        };
    }
}
