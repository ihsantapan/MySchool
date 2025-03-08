using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.ExamDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("Teacher/Exam")]
    public class ExamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

        [HttpGet]
        [Route("CreateExam")]
        public IActionResult CreateExam()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınavlar";
            ViewBag.v3 = "Sınav Listesi";
            ViewBag.v0 = "Sınav İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateExam")]
        public async Task<IActionResult> CreateExam(CreateExamDto createExamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createExamDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Exam/CreateExam", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Exam", new { area = "Teacher" });
            }

            return View();
        }

        [Route("DeleteExam/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Exam/DeleteExam?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Exam", new { area = "Teacher" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateExam/{id}")]
        public async Task<IActionResult> UpdateExam(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınavlar";
            ViewBag.v3 = "Sınav Listesi";
            ViewBag.v0 = "Sınav İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Exam/ExamGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateExamDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateExam/{id}")]
        public async Task<IActionResult> UpdateExam(UpdateExamDto updateExamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateExamDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Exam/UpdateExam", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Exam", new { area = "Teacher" });
            }

            return View();
        }
    }
}
