using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Data.Models.RequestModels.Member;
using Co_ParentingApp.Data.ReturnModels.Member;
using Microsoft.AspNetCore.Mvc;

namespace Co_ParentingApp.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public sealed class MemberController : ControllerBase
{

    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MemberModel>> CreateMemberAsync(CreateMemberRequest member)
    {
        try
        {
            var createdMember = await _memberService.CreateMemberAsync(member);

            return CreatedAtRoute(
                "GetMemberById",
                new { memberId = createdMember.Id },  
                createdMember);

        }
        catch (ConflictUsernameEmailException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MemberModel>> LoginUserAsync(LoginRequest request)
    {
        try
        {
            var user = await _memberService.LoginUserAsync(request);
            return Ok(user);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidPasswordException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("{memberId:guid}", Name = "GetMemberById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMemberAsync(Guid memberId)
    {
        var member = await _memberService.GetMemberAsync(memberId);
        if (member == null)
            return NotFound();
        return Ok(member);
    }
}