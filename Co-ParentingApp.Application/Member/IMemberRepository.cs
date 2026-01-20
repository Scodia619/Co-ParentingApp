using Co_ParentingApp.Data.Models.EntityModels;

namespace Co_ParentingApp.Application.Member
{
    public interface IMemberRepository
    {
        Task<MemberEntity> CreateMemberAsync(MemberEntity user);
        Task<IEnumerable<MemberEntity>> GetUserByUsernameOrEmail(string email, string username);
        Task<MemberEntity?> GetMemberAsync(Guid memberId);
        Task<MemberEntity?> GetMemberByPairingCodeAsync(string pairingKey);
        Task<MemberEntity?> LoginUserAsync(string username);
    }
}
