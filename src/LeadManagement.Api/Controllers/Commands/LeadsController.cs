using LeadManagement.Api.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LeadManagement.Api.Controllers.Commands;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Accepts a lead (applies a discount if needed and sends a notification).
    /// </summary>
    [HttpPost("{id:int}/accept")]
    public async Task<IActionResult> AcceptLead([FromRoute]
    [Required]
    [Range(1, int.MaxValue)] int id)
    {

        try
        {
            await _mediator.Send(new AcceptLeadCommand(id));
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Declines a lead.
    /// </summary>
    [HttpPost("{id:int}/decline")]
    public async Task<IActionResult> DeclineLead([FromRoute]
    [Required]
    [Range(1, int.MaxValue)] int id)
    {

        try
        {
            await _mediator.Send(new DeclineLeadCommand(id));
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
