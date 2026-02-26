using Co_ParentingApp.Application.Message;
using Co_ParentingApp.Application.Redis;
using Co_ParentingApp.Data.DbContexts;
using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Infrastructure.Message;
public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _dbContext;

    public MessageRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MessageEntity> CreateMessageAsync(MessageEntity message)
    {
        _dbContext.Message.Add(message);
        await _dbContext.SaveChangesAsync();
        return message;
    }

    public async Task<MessageEntity?> GetMessageById(Guid messageId)
    {
        return await _dbContext.Message.Where(x => x.MessageId == messageId).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<MessageEntity>> GetMessagesByConversationIdAsync(Guid conversationId)
    {
        var query = _dbContext.Message.Where(m => m.ConversationId == conversationId);

        query = query.OrderByDescending(m => m.CreatedAt);

        var result = await query.ToListAsync();
        return result;
    }

    public async Task<DateTime> GetLastMessageAsync(Guid conversationId)
    {
        var message = await _dbContext.Message.Where(m => m.ConversationId == conversationId).OrderByDescending(m => m.CreatedAt).FirstOrDefaultAsync();

        return message.CreatedAt;
    }
}
