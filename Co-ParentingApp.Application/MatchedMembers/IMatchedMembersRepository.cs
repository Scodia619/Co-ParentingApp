using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.MatchedMembers;
public interface IMatchedMembersRepository
{
    Task<MatchedMemberEntity> CreateMatchedMembersAsync(MatchedMemberEntity matchedMembers);
    Task<MatchedMemberEntity?> GetMatchedMembersAsync(Guid matchId);
    Task<MatchedMemberEntity?> GetMatchedMembersByIdsAsync(Guid matchingMemberId, Guid matchedMemberId);
}
