using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Data.Models.DTO;

namespace Co_ParentingApp.Application.ConversationMembers;

public class ConversationMemberService : IConversationMemberService
{
    private readonly IConversationMemberRepository _conversationMemberRepository;

    public ConversationMemberService(IConversationMemberRepository conversationMemberRepository)
    {
        _conversationMemberRepository = conversationMemberRepository;
    }

    public async Task<int> GetUnreadMessageCountAllConversationsAsync(Guid memberId)
    {
        return await _conversationMemberRepository.GetUnreadMessageCountAllConversationsAsync(memberId);
    }

    public async Task<List<ConversationUnreadDto>> GetUnreadMessagesPerConversationAsync(Guid memberId)
    {
        return await _conversationMemberRepository.GetUnreadMessagesPerConversationAsync(memberId);
    }

    public async Task MarkConversationAsReadAsync(Guid memberId, Guid conversationId)
    {
        var conversationMember = await _conversationMemberRepository
            .GetConversationMembersByMemberIdAndConversationId(memberId, conversationId);

        if (conversationMember == null)
            throw new NotFoundException("Conversation member not found.");

        conversationMember.LastReadAt = DateTime.UtcNow;

        await _conversationMemberRepository.UpdateAsync(conversationMember);
    }

}
