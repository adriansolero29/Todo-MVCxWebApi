using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Todo.MvcUI.Models;
using Todo.MvcUI.ViewModels;

namespace Todo.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            this._httpClient = httpClient.CreateClient("TodoAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Task");
            var memberResponse = await _httpClient.GetAsync("Member");

            if (!response.IsSuccessStatusCode)
                return Error();

            if (!memberResponse.IsSuccessStatusCode)
                return Error();

            var memberData = await memberResponse.Content.ReadAsStringAsync();
            var jsonMemberData = JsonSerializer.Deserialize<IEnumerable<MemberOL>>(memberData, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            ViewBag.MemberList = jsonMemberData;

            var data = await response.Content.ReadAsStringAsync();
            var jsonOutput = JsonSerializer.Deserialize<IEnumerable<TaskOL>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return View(jsonOutput);
        }

        public async Task<IActionResult> CreateSubTask([Bind("TaskId,Name")] SubTaskOL subTask)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("AddSubTaskModal");
            }

            var response = await _httpClient.PostAsJsonAsync("SubTask", subTask);
            if (!response.IsSuccessStatusCode)
                return Error();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeDueDate(long Id, DateTime DueDate)
        {
            var response = await _httpClient.PostAsJsonAsync($"Task/{Id}/{DueDate:o}", DueDate);
            if (!response.IsSuccessStatusCode)
                return Error();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateTask([Bind("Name,DueDate")] TaskOL task)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("AddTaskModal");
            }

            var response = await _httpClient.PostAsJsonAsync("Task", task);
            if (!response.IsSuccessStatusCode)
                return Error();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SetAssignee(long taskId, long memberId)
        {
            var data = new { taskId, memberId };
            var response = await _httpClient.PostAsJsonAsync($"Task/setAssignee/{taskId}/{memberId}", taskId);
            if (!response.IsSuccessStatusCode)
                return Error();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
