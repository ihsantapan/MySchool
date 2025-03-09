using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.AssignmentDtos;
using Newtonsoft.Json;

namespace MySchool.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/Assignment")]
    public class AsignmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AsignmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ödevler";
            ViewBag.v3 = "Ödev Listesi";
            ViewBag.v0 = "Ödev İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Assignment/AssignmentList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAssignmentDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
