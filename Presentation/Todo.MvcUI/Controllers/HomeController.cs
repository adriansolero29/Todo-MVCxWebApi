using Microsoft.AspNetCore.Mvc;
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
            if (!response.IsSuccessStatusCode)
                return Error();

            var data = await response.Content.ReadAsStringAsync();
            var jsonOutput = JsonSerializer.Deserialize<IEnumerable<TaskOL>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

            return View(jsonOutput);
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
