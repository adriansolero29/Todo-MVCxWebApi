using Microsoft.AspNetCore.Mvc;
using Todo.MvcUI.Models;

namespace Todo.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin(UserOL request)
        {
            return Ok();
        }

    }
}
