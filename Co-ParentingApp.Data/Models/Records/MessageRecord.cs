using Co_ParentingApp.Data.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace Co_ParentingApp.Data.Models.Records;

public class MessageRecord
{
    public Guid MessageId { get; set; }
    public Guid ConversationId { get; set; }
    public Guid SenderId { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public ConversationEntity Conversation { get; set; }
    public MemberEntity Sender { get; set; }
}