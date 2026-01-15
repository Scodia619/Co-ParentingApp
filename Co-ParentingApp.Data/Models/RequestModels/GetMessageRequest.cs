namespace Co_ParentingApp.Data.Models.RequestModels;

public class GetMessageRequest
{
    public Guid ConversationId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime? CreatedAt { get; set; }
}

