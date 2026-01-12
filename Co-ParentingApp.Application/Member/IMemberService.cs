using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Member;

namespace Co_ParentingApp.Application.Member;

public interface IMemberService
{
    Task<MemberRecord> CreateMemberAsync(CreateMemberRequest memberDto);
    Task<MemberRecord> GetMemberAsync(Guid memberId);
    Task<MemberRecord> LoginUserAsync(LoginRequest request);
}

