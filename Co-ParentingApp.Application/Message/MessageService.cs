using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Message;

namespace Co_ParentingApp.Application.Message;

public class MessageService : IMessageService
{
    private readonly IMessageMapper _messageMapper;
    private readonly IMessageRepository _messageRepository;
    private readonly IConversationMemberRepository _conversationMemberRepository;
    private readonly IConversationRepository _conversationRepository;

    public MessageService(IMessageMapper messageMapper, IMessageRepository messageRepository, IConversationMemberRepository conversationMemberRepository,
        IConversationRepository conversationRepository)
    {
        _messageMapper = messageMapper;
        _messageRepository = messageRepository;
        _conversationMemberRepository = conversationMemberRepository;
        _conversationRepository = conversationRepository;
    }

    public async Task<MessageRecord> CreateMessageAsync(CreateMessageRequest request)
    {
        var memberCheck = await _conversationMemberRepository.GetConversationMembersByMemberIdAndConversationId(request.SenderId, request.ConversationId);

        if (memberCheck == null) throw new NotFoundException("Member not in conversation");

        var message = _messageMapper.MapToEntity(request);
        
        var messageResult = await _messageRepository.CreateMessageAsync(message);

        await _conversationRepository.UpdateLastMessageByConversationId(messageResult.ConversationId, messageResult.Content, messageResult.CreatedAt);

        return _messageMapper.MapToRecord(messageResult);
    }

    public async Task<MessageRecord?> GetMessageById(Guid messageId)
    {
        var message = await _messageRepository.GetMessageById(messageId);
        return _messageMapper.MapToRecord(message);
    }
}
