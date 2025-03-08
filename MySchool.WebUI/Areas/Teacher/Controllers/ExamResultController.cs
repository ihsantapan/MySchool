using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.ExamResultsDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("Teacher/ExamResult")]
    public class ExamResultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExamResultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınav Sonuçları";
            ViewBag.v3 = "Sınav Sonuç Listesi";
            ViewBag.v0 = "Sınav Sonuç İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/ExamResult/ExamResultList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultExamResultDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateExamResult")]
        public IActionResult CreateExamResult()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınav Sonuçları";
            ViewBag.v3 = "Sınav Sonuç Listesi";
            ViewBag.v0 = "Sınav Sonuç İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateExamResult")]
        public async Task<IActionResult> CreateExamResult(CreateExamResultDto createExamResultDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createExamResultDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/ExamResult/CreateExamResult", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ExamResult", new { area = "Teacher" });
            }

            return View();
        }

        [Route("DeleteExamResult/{id}")]
        public async Task<IActionResult> DeleteExamResult(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/ExamResult/DeleteExamResult?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ExamResult", new { area = "Teacher" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateExamResult/{id}")]
        public async Task<IActionResult> UpdateExamResult(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınavlar";
            ViewBag.v3 = "Sınav Listesi";
            ViewBag.v0 = "Sınav İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/ExamResult/ExamResultGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateExamResultDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateExamResult/{id}")]
        public async Task<IActionResult> UpdateExamResult(UpdateExamResultDto updateExamResultDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateExamResultDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/ExamResult/UpdateExamResult", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ExamResult", new { area = "Teacher" });
            }

            return View();
        }

    }
}
