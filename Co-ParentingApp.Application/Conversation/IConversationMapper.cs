using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.RequestModels.Conversation;

namespace Co_ParentingApp.Application.Conversation;

public interface IConversationMapper
{
    ConversationsReturnModel ToReturnModel(ConversationReturnEntity entity);
    IReadOnlyCollection<ConversationsReturnModel> ToReturnModels(IEnumerable<ConversationReturnEntity> entities);
}