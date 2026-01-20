namespace Co_ParentingApp.Data.Models.RequestModels.MatchedMembers;

public class CreateMatchedMembersRequest
{
    public Guid MatchingId { get; set; }
    public string PairingKey { get; set; }
}
