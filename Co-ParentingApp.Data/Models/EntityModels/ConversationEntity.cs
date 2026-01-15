namespace Co_ParentingApp.Data.Models.EntityModels;
public class ConversationEntity
{
    public Guid ConversationId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string LastMessage { get; set; }
    public DateTime LastMessageAt { get; set; }

    public ICollection<ConversationMembersEntity> Members { get; set; }
    public ICollection<MessageEntity> Messages { get; set; }
}