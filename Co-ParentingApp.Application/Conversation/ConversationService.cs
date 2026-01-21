using Co_ParentingApp.Data.Models.RequestModels.Conversation;

namespace Co_ParentingApp.Application.Conversation;

public class ConversationService : IConversationService
{
    private readonly IConversationRepository _conversationRepository;
    private readonly IConversationMapper _conversationMapper;

    public ConversationService(IConversationRepository conversationRepository, IConversationMapper conversationMapper)
    {
        _conversationRepository = conversationRepository;
        _conversationMapper = conversationMapper;
    }

    public async Task<IReadOnlyCollection<ConversationsReturnModel>> GetConversationsByMemberIdAsync(Guid memberId)
    {
        var conversations = await _conversationRepository.GetConversationsByMemberIdAsync(memberId);

        return _conversationMapper.ToReturnModels(conversations);
    }
}
