using Co_ParentingApp.Application.MatchedMembers;
using Co_ParentingApp.Application.Member;
using Co_ParentingApp.Data.Models.RequestModels.MatchedMembers;
using Co_ParentingApp.Data.Models.RequestModels.Member;
using Co_ParentingApp.Data.ReturnModels.Member;
using Microsoft.AspNetCore.Mvc;

namespace Co_ParentingApp.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class MatchedMembersController : ControllerBase
{
    private readonly IMatchedMembersService _matchedMembersService;

    public MatchedMembersController(IMatchedMembersService matchedMembersService)
    {
        _matchedMembersService = matchedMembersService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MemberModel>> CreateMemberAsync(CreateMatchedMembersRequest request)
    {
        try
        {
            var createdMatchedMember = await _matchedMembersService.CreateMatchedMembersAsync(request);

            return CreatedAtRoute(
                "GetMatchedMembersById",
                new { matchId = createdMatchedMember.MatchId },
                createdMatchedMember);

        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet("{matchId:guid}", Name = "GetMatchedMembersById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMatchedMembersAsync(Guid matchId)
    {
        var member = await _matchedMembersService.GetMatchedMembersAsync(matchId);
        if (member == null)
            return NotFound();
        return Ok(member);
    }
}