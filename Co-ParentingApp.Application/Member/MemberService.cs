using Co_ParentingApp.Data.Models.EntityModels;
using Co_ParentingApp.Data.Models.Records;
using Co_ParentingApp.Data.Models.RequestModels.Member;
using Co_ParentingApp.Data.ReturnModels.Member;
using System.Security.Cryptography;

namespace Co_ParentingApp.Application.Member;

internal sealed class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberRecord> CreateMemberAsync(CreateMemberRequest request)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var checkUser = await _memberRepository.GetUserByUsernameOrEmail(request.Email, request.Username);

        if (checkUser.Count() != 0)
        {
            throw new ConflictUsernameEmailException("Username or Email already exists");
        }

        var user = new MemberEntity
        {
            Username = request.Username,
            Email = request.Email,
            Password = hashedPassword,
            CreatedAt = DateTime.UtcNow,
            PairingKey = GenerateReadable(),
        };

        var createdMember = await _memberRepository.CreateMemberAsync(user);

        return new MemberRecord
        {
            Id = createdMember.Id,
            Username = createdMember.Username,
            Email = createdMember.Email,
            CreatedAt = createdMember.CreatedAt,
            PairingKey = createdMember.PairingKey,
        };
    }

    public async Task<MemberRecord> GetMemberAsync(Guid memberId)
    {
        var member = await _memberRepository.GetMemberAsync(memberId);
        return new MemberRecord
        {
            Id = member.Id,
            Username = member.Username,
            Email = member.Email,
            CreatedAt = member.CreatedAt,
            PairingKey = member.PairingKey,
        };
    }

    public async Task<MemberRecord> LoginUserAsync(LoginRequest request)
    {
        var member = await _memberRepository.LoginUserAsync(request.Username);

        if (member == null) throw new UserNotFoundException("Username not found");

        var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, member.Password);

        if (!validPassword) throw new InvalidPasswordException("Incorrect password");


        return new MemberRecord
        {
            Id = member.Id,
            Username = member.Username,
            Email = member.Email,
            CreatedAt = member.CreatedAt,
            PairingKey = member.PairingKey,
        };

    }

    internal static string GenerateReadable(int length = 6)
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        return string.Concat(
            Enumerable.Range(0, length)
                .Select(_ => chars[RandomNumberGenerator.GetInt32(chars.Length)]));
    }
}