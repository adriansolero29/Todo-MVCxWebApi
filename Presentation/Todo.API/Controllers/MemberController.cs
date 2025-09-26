using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.API.Models;
using Todo.UseCases.MemberUseCases;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly CreateMember createMember;
        private readonly GetMembers getMembers;

        public MemberController(
            CreateMember createMember,
            GetMembers getMembers
            )
        {
            this.createMember = createMember;
            this.getMembers = getMembers;
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewMember([FromBody] MemberDTO obj)
        {
            try
            {
                await createMember.ExecuteCreateMember(obj.First, obj.Last);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error occured saving member: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var res = await getMembers.ExecuteAllAsync();
            return Ok(res);
        }
    }
}
