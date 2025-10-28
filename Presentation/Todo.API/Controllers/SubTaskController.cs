using Microsoft.AspNetCore.Mvc;
using Todo.API.Models;
using Todo.UseCases.SubTaskUseCases;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly CreateSubTask createSubTask;

        public SubTaskController(CreateSubTask createSubTask)
        {
            this.createSubTask = createSubTask;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubTaskDTO obj)
        {
            try
            {
                if (obj == null) return NotFound();
                await createSubTask.ExecuteAsync(obj.TaskId, obj?.Name ?? "");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error occured saving task: " + ex.Message });
            }
        }
    }
}
