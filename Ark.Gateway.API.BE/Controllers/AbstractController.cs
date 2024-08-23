using Ark.Gateway.Domain.CommandHandler.AbstractDetails;
using Ark.Gateway.Domain.QueryHandlers.AbstractDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractController : ControllerBase
    {
        private readonly Mediator _mediator;

        public AbstractController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddAbstract")]
        public IActionResult Create([FromBody] AddAbstractCommand command)
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

        [HttpGet("GetAbstract")]
        public IActionResult Abstract(Guid abstractId)
        {
            var result = _mediator.Dispatch(new GetAbstractByAbstractIdQuery { AbstractId = abstractId });
            return Ok(result);
        }

        [HttpGet("GetAbstracts")]
        public IActionResult Abstracts()
        {
            var result = _mediator.Dispatch(new GetAbstractsQuery { });
            return Ok(result);
        }

        [HttpPost("UpdateAbstract")]
        public IActionResult Update(UpdateAbstractCommand command)
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

        [HttpPost("DeleteAbstract")]
        public IActionResult Delete(DeleteAbstractCommand command)
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
