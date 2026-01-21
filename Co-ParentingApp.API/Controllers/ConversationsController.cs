using Co_ParentingApp.Application.Conversation;
using Microsoft.AspNetCore.Mvc;

namespace Co_ParentingApp.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ConversationsController : ControllerBase
{

    private readonly IConversationService _conversationService;

    public ConversationsController(IConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetConversationsByMemberId(Guid memberId)
    {
        try
        {
            var conversations = await _conversationService.GetConversationsByMemberIdAsync(memberId);

            if (conversations == null) return NotFound();

            return Ok(conversations);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

