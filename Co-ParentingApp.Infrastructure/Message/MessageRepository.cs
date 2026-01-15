using Co_ParentingApp.Application.Message;
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

    public async Task<IReadOnlyCollection<MessageEntity>> GetPaginatedMessagesByConversationIdAsync(Guid conversationId, DateTime? before = null, int pageSize = 20)
    {
        var query = _dbContext.Message.Where(m => m.ConversationId == conversationId);

        if (before.HasValue)
        {
            query = query.Where(m => m.CreatedAt < before.Value);
        }

        query = query.OrderByDescending(m => m.CreatedAt);

        return await query.Take(pageSize).Include(m => m.Sender).ToListAsync();
    }
}
