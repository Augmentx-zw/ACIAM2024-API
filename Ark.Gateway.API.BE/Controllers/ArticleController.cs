using Ark.Gateway.Domain.CommandHandler.ArticleDetails;
using Ark.Gateway.Domain.QueryHandlers.ArticleDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ark.Gateway.API.BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly Mediator _mediator;

        public ArticleController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddArticle")]
        public IActionResult Create([FromBody] AddArticleCommand command)
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

        [HttpGet("GetArticle")]
        public IActionResult Article(Guid ArticleId)
        {
            var result = _mediator.Dispatch(new GetArticleByArticleIdQuery { ArticleId = ArticleId });
            return Ok(result);
        }

        [HttpGet("GetArticles")]
        public IActionResult Articles()
        {
            var result = _mediator.Dispatch(new GetArticlesQuery { });
            return Ok(result);
        }

        [HttpPost("UpdateArticle")]
        public IActionResult Update(UpdateArticleCommand command)
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

        [HttpPost("DeleteArticle")]
        public IActionResult Delete(DeleteArticleCommand command)
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
