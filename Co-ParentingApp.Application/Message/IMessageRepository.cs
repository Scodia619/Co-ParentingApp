using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.Message;

public interface IMessageRepository
{
    Task<MessageEntity> CreateMessageAsync(MessageEntity message);
    Task<MessageEntity?> GetMessageById(Guid messageId);
}

