using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Application.Realtime;
using Co_ParentingApp.Application.Redis;
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
    private readonly IRedisService _redisService;

    public MessageService(IMessageMapper messageMapper, IMessageRepository messageRepository, IConversationMemberRepository conversationMemberRepository,
        IConversationRepository conversationRepository, IChatNotifier chatNotifier, IRedisService redisService)
    {
        _messageMapper = messageMapper;
        _messageRepository = messageRepository;
        _conversationMemberRepository = conversationMemberRepository;
        _conversationRepository = conversationRepository;
        _chatNotifier = chatNotifier;
        _redisService = redisService;
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

        var redisKey = $"messages-{request.ConversationId}-{request.MemberId}";
        var messages = await _redisService.GetAsync<IReadOnlyCollection<MessageRecord>>(redisKey);

        if (messages == null)
        {
            messages = await GetNewMessages(request.ConversationId, redisKey);
        }

        var latestCachedMessageTime = messages.Max(m => m.CreatedAt);
        var lastMessageTime = await _messageRepository.GetLastMessageAsync(request.ConversationId);

        if (latestCachedMessageTime <= lastMessageTime)
        {
            messages = await GetNewMessages(request.ConversationId, redisKey);
        }

        if (request.Before.HasValue)
        {
            messages = messages.Where(m => m.CreatedAt < request.Before.Value).ToList();
        }

        messages = messages
            .OrderByDescending(m => m.CreatedAt)
            .Take(20)
            .ToList()
            .AsReadOnly();

        return messages;
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

    internal async Task<IReadOnlyCollection<MessageRecord>> GetNewMessages(Guid conversationId, string redisKey)
    {
        var newMessages = await _messageRepository.GetMessagesByConversationIdAsync(conversationId);
        var newMessageRecords = newMessages.Select(message => _messageMapper.MapToRecord(message)).ToList();
        await _redisService.SetAsync<IReadOnlyCollection<MessageRecord>>(redisKey, newMessageRecords, TimeSpan.FromMinutes(5));
        return newMessageRecords;
    }
}
