namespace Co_ParentingApp.Data.ReturnModels.Member;

public class MemberModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PairingKey { get; set; }
}