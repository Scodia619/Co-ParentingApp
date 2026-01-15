using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Message;

namespace Co_ParentingApp.Application.Message;

internal class MessageMapper : IMessageMapper
{
    public MessageEntity MapToEntity(CreateMessageRequest request)
    {
        return new MessageEntity
        {
            ConversationId = request.ConversationId,
            SenderId = request.SenderId,
            Content = request.Content
        };
    }

    public MessageRecord MapToRecord(MessageEntity message)
    {
        return new MessageRecord
        {
            MessageId = message.MessageId,
            ConversationId = message.ConversationId,
            SenderId = message.SenderId,
            Content = message.Content,
            CreatedAt = message.CreatedAt
        };
    }
}
