using Co_ParentingApp.Application.Conversation;
using Co_ParentingApp.Data.DbContexts;
using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Infrastructure.Conversation;

public class ConversationRepository : IConversationRepository
{
    private readonly AppDbContext _dbContext;

    public ConversationRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ConversationEntity> CreateConversationAsync(ConversationEntity conversation)
    {
        _dbContext.Conversation.Add(conversation);
        await _dbContext.SaveChangesAsync();
        return conversation;
    }

    public async Task UpdateLastMessageByConversationId(Guid conversationId, string content, DateTime time)
    {
        var conversation = await _dbContext.Conversation.FindAsync(conversationId);
        conversation.LastMessage = content;
        conversation.LastMessageAt = time;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<ConversationReturnEntity>?> GetConversationsByMemberIdAsync(Guid memberId)
    {
        return await _dbContext.Conversation
        .Where(c => c.Members.Any(cm => cm.MemberId == memberId))
        .Select(c => new ConversationReturnEntity
        {
            ConversationId = c.ConversationId,

            ParticipantId = c.Members
                .Where(cm => cm.MemberId != memberId)
                .Select(cm => cm.Member.Id)
                .FirstOrDefault(),

            ParticipantName = c.Members
                .Where(cm => cm.MemberId != memberId)
                .Select(cm => cm.Member.Username)
                .FirstOrDefault(),

            LastMessage = c.LastMessage,
            LastMessageAt = c.LastMessageAt
        })
        .OrderByDescending(c => c.LastMessageAt)
        .ToListAsync();
    }
}