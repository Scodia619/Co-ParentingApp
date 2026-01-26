namespace Co_ParentingApp.Data.Models.RequestModels.Conversation;

public class ConversationsReturnModel
{
    public Guid ConversationId { get; set; }
    public Guid ParticipantId { get; set; }
    public string ParticipantName { get; set; }
    public string? LastMessage { get; set; }
    public DateTime? LastMessageAt { get; set; }
    public int? UnreadCount { get; set; }
}
