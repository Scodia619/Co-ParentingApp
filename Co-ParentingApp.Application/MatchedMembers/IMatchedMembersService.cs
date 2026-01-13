using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.MatchedMembers;

namespace Co_ParentingApp.Application.MatchedMembers;

public interface IMatchedMembersService
{
    Task<MatchedMemberRecord> CreateMatchedMembersAsync(CreateMatchedMembersRequest request);
    Task<MatchedMemberRecord?> GetMatchedMembersAsync(Guid matchId);
}