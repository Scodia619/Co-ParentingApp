using Co_ParentingApp.Application.ConversationMembers;
using Co_ParentingApp.Data.DbContexts;
using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Infrastructure.ConversationMembers;

public class ConversationMembersRepository : IConversationMemberRepository
{
    private readonly AppDbContext _dbContext;

    public ConversationMembersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ConversationMembersEntity> CreateConversationMembersAsync(ConversationMembersEntity conversationMembers)
    {
        _dbContext.ConversationMembers.Add(conversationMembers);
        await _dbContext.SaveChangesAsync();
        return conversationMembers;
    }

    public async Task<ConversationMembersEntity?> GetConversationMembersByMemberIdAndConversationId(Guid memberId, Guid conversationId)
    {
        return await _dbContext.ConversationMembers.Where(x => x.MemberId == memberId && x.ConversationId == conversationId).FirstOrDefaultAsync();
    }
}