using LearnHubApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace LearnHubApp.Controllers
{
    public class CategorieClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllFormations()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:7070")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Categories/get-all-Categories");

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<IEnumerable<CategorieClient>>();
                return View(categories);
            }
            else
            {
                return View();
            }
        }
    }
}
