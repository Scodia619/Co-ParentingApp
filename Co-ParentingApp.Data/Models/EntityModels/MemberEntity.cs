namespace Co_ParentingApp.Data.Models.EntityModels
{
    public class MemberEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PairingKey { get; set; } = string.Empty;
    }
}
