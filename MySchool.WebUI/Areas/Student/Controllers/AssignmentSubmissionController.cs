using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.AssignmentSubmissionDtos;
using Newtonsoft.Json;

namespace MySchool.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/AssignmentSubmission")]
    public class AssignmentSubmissionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AssignmentSubmissionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ödev Paylaşımı";
            ViewBag.v3 = "Ödev Paylaşım Listesi";
            ViewBag.v0 = "Ödev Paylaşım İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/AssignmentSubmission/AssignmentSubmissionList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAsignmentSubmissionDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
