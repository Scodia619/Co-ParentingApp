using Co_ParentingApp.Application.ConversationMembers;
using Microsoft.AspNetCore.Mvc;

namespace Co_ParentingApp.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class ConversationMemberController : ControllerBase
{
    private readonly IConversationMemberService _conversationMemberService;

    public ConversationMemberController(IConversationMemberService conversationMemberService)
    {
        _conversationMemberService = conversationMemberService;
    }

    [HttpGet("unread-tab-count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUnreadConversationsCount(Guid memberId)
    {
        var count = await _conversationMemberService.GetUnreadMessageCountAllConversationsAsync(memberId);
        return Ok(count);
    }

    [HttpGet("unread-per-conversation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUnreadPerConversation(Guid memberId)
    {
        var unreadCounts = await _conversationMemberService.GetUnreadMessagesPerConversationAsync(memberId);
        return Ok(unreadCounts);
    }

    [HttpPost("{conversationId}/read")]
    public async Task<IActionResult> MarkConversationAsRead(Guid conversationId, [FromQuery] Guid memberId)
    {
        try
        {
            await _conversationMemberService.MarkConversationAsReadAsync(memberId, conversationId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex);
        }
    }

}
