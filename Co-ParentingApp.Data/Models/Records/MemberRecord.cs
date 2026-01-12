namespace Co_ParentingApp.Data.Models.Records
{
    public class MemberRecord
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PairingKey { get; set; }
    }
}
