namespace Co_ParentingApp.Data.Models.EntityModels;
public class ConversationEntity
{
    public Guid ConversationId { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? LastMessage { get; set; } = null;
    public DateTime? LastMessageAt { get; set; } = null;

    public ICollection<ConversationMembersEntity> Members { get; set; }
    public ICollection<MessageEntity> Messages { get; set; }
}