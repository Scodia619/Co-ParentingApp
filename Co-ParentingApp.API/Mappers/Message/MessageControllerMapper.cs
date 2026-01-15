using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.ReturnModels.Message;

namespace Co_ParentingApp.API.Mappers.Message;

internal class MessageControllerMapper : IMessageControllerMapper
{
    public MessageModel MapToModel(MessageRecord record)
    {
        return new MessageModel
        {
            MessageId = record.MessageId,
            SenderId = record.SenderId,
            Content = record.Content,
            CreatedAt = record.CreatedAt
        };
    }
}
