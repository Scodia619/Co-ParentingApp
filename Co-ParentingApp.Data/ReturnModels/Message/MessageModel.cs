namespace Co_ParentingApp.Data.ReturnModels.Message;

public class MessageModel
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public Guid SenderId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
