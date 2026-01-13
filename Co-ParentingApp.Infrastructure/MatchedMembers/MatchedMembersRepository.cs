using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Data.DbContexts;
using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Infrastructure.MatchedMembers;

public class MatchedMembersRepository : IMatchedMembersRepository
{
    private readonly AppDbContext _dbContext;

    public MatchedMembersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MatchedMemberEntity> CreateMatchedMembersAsync(MatchedMemberEntity matchedMembers)
    {
        _dbContext.MatchedMembers.Add(matchedMembers);
        await _dbContext.SaveChangesAsync();
        return matchedMembers;
    }

    public async Task<MatchedMemberEntity?> GetMatchedMembersByIdsAsync(Guid matchingMemberId, Guid matchedMemberId)
    {
        return await _dbContext.MatchedMembers.Where(x => x.MatchingMemberId == matchingMemberId && x.MatchedMemberId == matchedMemberId).FirstOrDefaultAsync();
    }

    public async Task<MatchedMemberEntity?> GetMatchedMembersAsync(Guid matchId)
    {
        return await _dbContext.MatchedMembers.Where(x => x.MatchId == matchId).FirstOrDefaultAsync();
    }
}