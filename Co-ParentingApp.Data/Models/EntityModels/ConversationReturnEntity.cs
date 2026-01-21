namespace Co_ParentingApp.Data.Models.EntityModels;
public class ConversationReturnEntity
{
    public Guid ConversationId { get; set; }
    public Guid ParticipantId { get; set; }
    public string ParticipantName { get; set; }
    public string? LastMessage { get; set; }
    public DateTime? LastMessageAt { get; set; }
}
