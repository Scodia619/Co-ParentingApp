using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Data.DbContexts;
using Co_ParentingApp.Data.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Co_ParentingApp.Infrastructure.Member;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _dbContext;

    public MemberRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MemberEntity> CreateMemberAsync(MemberEntity member)
    {
        _dbContext.Member.Add(member);
        await _dbContext.SaveChangesAsync();
        return member;
    }

    public async Task<IEnumerable<MemberEntity>> GetUserByUsernameOrEmail(string email, string username)
    {
        var response = await _dbContext.Member.Where(x => x.Username == username || x.Email == email).ToListAsync();
        return response;
    }

    public async Task<MemberEntity?> GetMemberAsync(Guid memberId)
    {
        return await _dbContext.Member.Where(x => x.Id == memberId).FirstOrDefaultAsync();
    }

    public async Task<MemberEntity?> LoginUserAsync(string username)
    {
        return await _dbContext.Member.Where(x => x.Username == username).FirstOrDefaultAsync();
    }
}
