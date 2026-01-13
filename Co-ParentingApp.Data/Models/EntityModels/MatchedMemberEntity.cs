namespace Co_ParentingApp.Data.Models.EntityModels;
public class MatchedMemberEntity
{
    public Guid MatchId { get; set; }
    public Guid MatchingMemberId { get; set; }
    public Guid MatchedMemberId { get; set; }
    public DateTime CreatedAt { get; set; }

    public MemberEntity MatchingMember { get; set; }
    public MemberEntity MatchedMember { get; set; }
}