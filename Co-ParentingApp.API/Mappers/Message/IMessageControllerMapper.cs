using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.ReturnModels.Message;

namespace Co_ParentingApp.API.Mappers.Message;

public interface IMessageControllerMapper
{
    MessageModel MapToModel(MessageRecord record);
}
