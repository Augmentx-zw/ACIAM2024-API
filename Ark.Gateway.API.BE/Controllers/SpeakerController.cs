using Ark.Gateway.Domain.CommandHandler.SpeakerDetails;
using Ark.Gateway.Domain.QueryHandlers.SpeakerDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly Mediator _mediator;

        public SpeakerController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddSpeaker")]
        public IActionResult Create([FromBody] AddSpeakerCommand command)
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

        [HttpGet("GetSpeaker")]
        public IActionResult Speaker(Guid speakerId)
        {
            var result = _mediator.Dispatch(new GetSpeakerBySpeakerIdQuery { SpeakerId = speakerId });
            return Ok(result);
        }

        [HttpGet("GetSpeakers")]
        public IActionResult Speakers()
        {
            var result = _mediator.Dispatch(new GetSpeakersQuery { });
            return Ok(result);
        }

        [HttpPost("UpdateSpeaker")]
        public IActionResult Update(UpdateSpeakerCommand command)
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

        [HttpPost("DeleteSpeaker")]
        public IActionResult Delete(DeleteSpeakerCommand command)
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
