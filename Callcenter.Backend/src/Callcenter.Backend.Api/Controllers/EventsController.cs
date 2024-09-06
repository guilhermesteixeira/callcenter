using Callcenter.Backend.Api.Controllers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

[Route("events")]
public class EventsController(ISender _mediator) : ApiController
{
    [HttpPost("agents")]
    public async Task<IActionResult> CreateAgentEvent(AgentEventRequest request)
    {
        var command = new CreateAgentEventCommand(request.AgentId, request.AgentName, request.TimestampUtc, request.Action, request.QueueIds);

        var result = await _mediator.Send(command);

        return result.Match(
          _ => Ok(),
          Problem);
    }
}