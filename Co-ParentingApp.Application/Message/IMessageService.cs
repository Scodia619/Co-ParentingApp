using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Message;

namespace Co_ParentingApp.Application.Message;

public interface IMessageService
{
    Task<MessageRecord> CreateMessageAsync(CreateMessageRequest request);
    Task<MessageRecord?> GetMessageById(Guid messageId);
}
