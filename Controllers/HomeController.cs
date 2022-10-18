using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_Shelf_WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client =  _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/products");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseMessage = "Success";
            }
            else
            {
                ViewBag.ResponseMessage = "Failed";
            }
            return View();
        }
    }
}
