using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;

namespace Co_ParentingApp.Application.MatchedMembers;
internal class MatchedMemberMapper : IMatchedMemberMapper
{
    public MatchedMemberRecord MapToRecord(MatchedMemberEntity entity)
    {
        return new MatchedMemberRecord
        {
            MatchId = entity.MatchId,
            MatchingMemberId = entity.MatchingMemberId,
            MatchedMemberId = entity.MatchedMemberId,
            CreatedAt = entity.CreatedAt,
        };
    }

    public MatchedMemberEntity MapToEntity(Guid matchingMemberId, Guid matchedMemberId)
    {
        return new MatchedMemberEntity
        {
            MatchingMemberId = matchingMemberId,
            MatchedMemberId = matchedMemberId,
            CreatedAt = DateTime.UtcNow,
        };
    }
}

