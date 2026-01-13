using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Models;
using Todo.UseCases.UserUseCases;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUser createUser;

        public UserController(CreateUser createUser)
        {
            this.createUser = createUser;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO request)
        {
            try
            {
                if (request == null)
                    return NotFound();

                await createUser.ExecuteAsync(request.Username, request.Password);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error saving user" + ex.Message });
            }
        }
    }
}
