using Ark.Gateway.Domain.CommandHandler.RegistrationDetails;
using Ark.Gateway.Domain.QueryHandlers.RegistrationDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly Mediator _mediator;

        public RegistrationController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddRegistration")]
        public IActionResult Create([FromBody] AddRegistrationCommand command)
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

        [HttpGet("GetRegistration")]
        public IActionResult Registration(Guid registrationId)
        {
            var result = _mediator.Dispatch(new GetRegistrationByRegistrationIdQuery { RegistrationId = registrationId });
            return Ok(result);
        }

        [HttpGet("GetRegistrations")]
        public IActionResult Registrations()
        {
            var result = _mediator.Dispatch(new GetRegistrationsQuery { });
            return Ok(result);
        }

        [HttpPost("UpdateRegistration")]
        public IActionResult Update(UpdateRegistrationCommand command)
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

        [HttpPost("DeleteRegistration")]
        public IActionResult Delete(DeleteRegistrationCommand command)
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
