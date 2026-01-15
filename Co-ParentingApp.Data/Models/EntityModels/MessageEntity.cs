using System.ComponentModel.DataAnnotations;

namespace Co_ParentingApp.Data.Models.EntityModels;

public class MessageEntity
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public Guid ConversationId { get; set; }
    public Guid SenderId { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ConversationEntity Conversation { get; set; }
    public MemberEntity Sender { get; set; }
}