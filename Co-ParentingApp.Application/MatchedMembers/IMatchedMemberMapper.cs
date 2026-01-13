using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;

namespace Co_ParentingApp.Application.MatchedMembers;

public interface IMatchedMemberMapper
{
    MatchedMemberRecord MapToRecord(MatchedMemberEntity entity);
    MatchedMemberEntity MapToEntity(Guid matchingMemberId, Guid matchedMemberId);
}