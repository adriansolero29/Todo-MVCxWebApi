using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Models;
using Todo.UseCases.TaskUseCases;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly CreateTask createTask;
        private readonly GetTasks getTask;

        public TaskController(CreateTask createTask, GetTasks getTask)
        {
            this.createTask = createTask;
            this.getTask = getTask;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDTO obj)
        {
            try
            {
                if (obj == null) return NotFound();
                await createTask.ExecuteAsync(obj.Name ?? "", obj.DueDate, obj.AssignToMemberId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error occured saving task: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await getTask.ExecuteAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error occured getting all task: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await getTask.ExecuteOneAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error occured getting task: " + ex.Message });
            }
        }
    }
}
