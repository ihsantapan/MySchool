using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.ExamDtos;
using Newtonsoft.Json;

namespace MySchool.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/Exam")]
    public class ExamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async  Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınavlar";
            ViewBag.v3 = "Sınav Listesi";
            ViewBag.v0 = "Sınav İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Exam/ExamList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultExamDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
