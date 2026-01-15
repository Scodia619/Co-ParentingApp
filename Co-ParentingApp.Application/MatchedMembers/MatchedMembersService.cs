using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.MatchedMembers;

namespace Co_ParentingApp.Application.MatchedMembers;
internal sealed class MatchedMembersService : IMatchedMembersService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMatchedMembersRepository _matchedMembersRepository;
    private readonly IConversationRepository _conversationRepository;
    private readonly IConversationMemberRepository _conversationMemberRepository;
    private readonly IMatchedMemberMapper _matchedMemberMapper;
    private readonly IConversationMemberMapper _conversationMemberMapper;

    public MatchedMembersService(IMemberRepository memberRepository, IMatchedMembersRepository matchedMembersRepository, IMatchedMemberMapper matchedMemberMapper,
        IConversationRepository conversationRepository, IConversationMemberRepository conversationMemberRepository, IConversationMemberMapper conversationMemberMapper)
    {
        _memberRepository = memberRepository;
        _matchedMembersRepository = matchedMembersRepository;
        _matchedMemberMapper = matchedMemberMapper;
        _conversationRepository = conversationRepository;
        _conversationMemberMapper = conversationMemberMapper;
        _conversationMemberRepository = conversationMemberRepository;
    }

    public async Task<MatchedMemberRecord> CreateMatchedMembersAsync(CreateMatchedMembersRequest request)
    {
        var matchingMember = await _memberRepository.GetMemberAsync(request.MatchingId);

        if (matchingMember == null) throw new NotFoundException("Matching Member Not Found");

        var matchedMember = await _memberRepository.GetMemberAsync(request.MatchedId);

        if (matchedMember == null) throw new NotFoundException("Matched Member Not Found");

        if (matchedMember.PairingKey != request.PairingKey) throw new PairKeyException("Matched Member ID doesnt Match the Pairing Key");

        var matchedCheck = await _matchedMembersRepository.GetMatchedMembersByIdsAsync(matchingMember.Id, matchedMember.Id);

        if (matchedCheck != null) throw new AlreadyMatchedException("Already Matched");

        var entity = await _matchedMembersRepository.CreateMatchedMembersAsync(_matchedMemberMapper.MapToEntity(matchingMember.Id, matchedMember.Id));

        var conversation = new ConversationEntity();

        var conversationResult = await _conversationRepository.CreateConversationAsync(conversation);

        await _conversationMemberRepository.CreateConversationMembersAsync(_conversationMemberMapper.MapToEntity(conversationResult.ConversationId, matchedMember.Id));
        await _conversationMemberRepository.CreateConversationMembersAsync(_conversationMemberMapper.MapToEntity(conversationResult.ConversationId, matchingMember.Id));

        return _matchedMemberMapper.MapToRecord(entity);
    }

    public async Task<MatchedMemberRecord?> GetMatchedMembersAsync(Guid matchId)
    {
        var result = await _matchedMembersRepository.GetMatchedMembersAsync(matchId);
        return _matchedMemberMapper.MapToRecord(result);
    }
}