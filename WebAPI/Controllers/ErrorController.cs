


using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet("not-found")]
        public IActionResult ErrorNotFoundError()
        {
            return NotFound();
        }
        [HttpGet("bad-request")]
        public IActionResult ErrorBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("unauthorized")]
        public IActionResult ErrorUnauthorized()
        {
            return Unauthorized();
        }
        [HttpGet("validation-error")]
        public IActionResult ValidationError()
        {
            ModelState.AddModelError("Problem1", "This is the first validation error");
            ModelState.AddModelError("Problem2", "This is the second validation error");
            return ValidationProblem();
        }
        [HttpGet("server-error")]
        public IActionResult ServerError()
        {
            throw new Exception("server error");
        }


    }
}