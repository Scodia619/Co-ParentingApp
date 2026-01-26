namespace Co_ParentingApp.Data.Models.DTO;

public class ConversationUnreadDto
{
    public Guid ConversationId { get; set; }
    public int UnreadMessages { get; set; }
}