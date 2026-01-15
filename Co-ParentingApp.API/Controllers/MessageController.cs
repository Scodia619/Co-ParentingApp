using Co_ParentingApp.API.Mappers.Message;
using Co_ParentingApp.Application.Message;
using Co_ParentingApp.Data.Models.RequestModels.Message;
using Microsoft.AspNetCore.Mvc;

namespace Co_ParentingApp.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMessageControllerMapper _messageMapper;

    public MessageController(IMessageService messageService, IMessageControllerMapper messageMapper)
    {
        _messageService = messageService;
        _messageMapper = messageMapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateMessageAsync(CreateMessageRequest request)
    {
        try
        {
            var message = await _messageService.CreateMessageAsync(request);
            return CreatedAtRoute(
                "GetMessageByMemberId",
                new { messageId = message.MessageId },
                _messageMapper.MapToModel(message));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{messageId:guid}", Name = "GetMessageByMemberId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMatchedMembersAsync(Guid messageId)
    {
        var message = await _messageService.GetMessageById(messageId);
        if (message == null)
            return NotFound();
        return Ok(_messageMapper.MapToModel(message));
    }
}