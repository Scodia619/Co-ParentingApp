using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.Realtime;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels;
using Co_ParentingApp.Data.Models.RequestModels.Message;

namespace Co_ParentingApp.Application.Message;

public class MessageService : IMessageService
{
    private readonly IChatNotifier _chatNotifier;
    private readonly IMessageMapper _messageMapper;
    private readonly IMessageRepository _messageRepository;
    private readonly IConversationMemberRepository _conversationMemberRepository;
    private readonly IConversationRepository _conversationRepository;

    public MessageService(IMessageMapper messageMapper, IMessageRepository messageRepository, IConversationMemberRepository conversationMemberRepository,
        IConversationRepository conversationRepository, IChatNotifier chatNotifier)
    {
        _messageMapper = messageMapper;
        _messageRepository = messageRepository;
        _conversationMemberRepository = conversationMemberRepository;
        _conversationRepository = conversationRepository;
        _chatNotifier = chatNotifier;
    }

    public async Task<MessageRecord> CreateMessageAsync(CreateMessageRequest request)
    {
        await CheckConversationAuth(request.SenderId, request.ConversationId);

        var message = _messageMapper.MapToEntity(request);
        
        var messageResult = await _messageRepository.CreateMessageAsync(message);

        await _conversationRepository.UpdateLastMessageByConversationId(messageResult.ConversationId, messageResult.Content, messageResult.CreatedAt);

        var record = _messageMapper.MapToRecord(messageResult);

        await _chatNotifier.MessageSentAsync(messageResult.ConversationId, record);

        return record;
    }

    public async Task<IReadOnlyCollection<MessageRecord>> GetPaginatedMessagesByConversationIdAsync(GetMessageRequest request)
    {
        await CheckConversationAuth(request.MemberId, request.ConversationId);

        var messages = await _messageRepository.GetPaginatedMessagesByConversationIdAsync(request.ConversationId, request.CreatedAt);

        return messages.Select(message => _messageMapper.MapToRecord(message)).ToList();
    }

    public async Task<MessageRecord?> GetMessageById(Guid messageId)
    {
        var message = await _messageRepository.GetMessageById(messageId);
        return _messageMapper.MapToRecord(message);
    }

    internal async Task CheckConversationAuth(Guid senderId, Guid conversationId)
    {
        var memberCheck = await _conversationMemberRepository.GetConversationMembersByMemberIdAndConversationId(senderId, conversationId);

        if (memberCheck == null) throw new NotFoundException("Member not in conversation");
    }
}
