namespace Co_ParentingApp.Data.Models.EntityModels;

public class ConversationMembersEntity
{
    public Guid ConversationMemberId { get; set; }
    public Guid ConversationId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime JoinedAt { get; set; }

    public ConversationEntity Conversation { get; set; }
    public MemberEntity Member { get; set; }
}