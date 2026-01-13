namespace Co_ParentingApp.Data.Models.Records;
public class MatchedMemberRecord
{
    public Guid MatchId { get; set; }
    public Guid MatchingMemberId { get; set; }
    public Guid MatchedMemberId { get; set; }
    public DateTime CreatedAt { get; set; }
}
