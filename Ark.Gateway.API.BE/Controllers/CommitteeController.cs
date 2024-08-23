using Ark.Gateway.Domain.CommandHandler.CommitteeDetails;
using Ark.Gateway.Domain.QueryHandlers.CommitteeDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteeController : ControllerBase
    {
        private readonly Mediator _mediator;

        public CommitteeController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddCommittee")]
        public IActionResult Create([FromBody] AddCommitteeCommand command)
        {
            try
            {
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = true, ex.Message });
            }
        }

        [HttpGet("GetCommittee")]
        public IActionResult Committee(Guid committeeId)
        {
            var result = _mediator.Dispatch(new GetCommitteeByCommitteeIdQuery { CommitteeId = committeeId });
            return Ok(result);
        }

        [HttpGet("GetCommittees")]
        public IActionResult Committees()
        {
            var result = _mediator.Dispatch(new GetCommitteesQuery { });
            return Ok(result);
        }

        [HttpPost("UpdateCommittee")]
        public IActionResult Update(UpdateCommitteeCommand command)
        {
            try
            {
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Ok(new { Error = true, ex.Message });
            }
        }

        [HttpPost("DeleteCommittee")]
        public IActionResult Delete(DeleteCommitteeCommand command)
        {
            try
            {
                _mediator.Dispatch(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Ok(new { Error = true, ex.Message });
            }
        }
    }
}
