using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Message;

namespace Co_ParentingApp.Application.Message;

public interface IMessageMapper
{
    MessageEntity MapToEntity(CreateMessageRequest request);
    MessageRecord MapToRecord(MessageEntity message);
}
