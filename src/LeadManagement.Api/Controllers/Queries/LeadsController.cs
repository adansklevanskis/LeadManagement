using LeadManagement.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.Api.Controllers.Queries;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ILeadQuery _leadQuery;

    public LeadsController(ILeadQuery leadQuery)
    {
        _leadQuery = leadQuery;
    }

    /// <summary>
    /// Gets all leads that are in the Invited status.
    /// </summary>
    [HttpGet("invited")]
    public async Task<IActionResult> GetInvitedLeads()
    {
        var leads = await _leadQuery.GetInvitedLeadsAsync();
        return Ok(leads);
    }

    /// <summary>
    /// Gets all leads that have been accepted.
    /// </summary>
    [HttpGet("accepted")]
    public async Task<IActionResult> GetAcceptedLeads()
    {
        var leads = await _leadQuery.GetAcceptedLeadsAsync();
        return Ok(leads);
    }

}
