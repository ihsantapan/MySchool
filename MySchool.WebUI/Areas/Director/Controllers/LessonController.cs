using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.LessonDtos;
using MySchool.FrontendDtoLayer.Dtos.TeacherDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Director.Controllers
{
    [Area("Director")]
    [Route("Director/Lesson")]
    public class LessonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LessonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Dersler";
            ViewBag.v3 = "Ders Listesi";
            ViewBag.v0 = "Ders İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Lesson/LessonList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLessonDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("CreateLesson")]
        [HttpGet]
        public IActionResult CreateLesson()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Dersler";
            ViewBag.v3 = "Ders Listesi";
            ViewBag.v0 = "Ders İşlemleri";
            return View();
        }

        [Route("CreateLesson")]
        [HttpPost]
        public async Task<IActionResult> CreateLesson(CreateLessonDto createLessonDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLessonDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Lesson/CreateLesson", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Lesson", new { area = "Director" });
            }

            return View();
        }

        [Route("DeleteLesson/{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Lesson/DeleteLesson?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Lesson", new { area = "Director" });
            }
            return View();
        }

        [Route("UpdateLesson/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateLesson(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Dersler";
            ViewBag.v3 = "Ders Listesi";
            ViewBag.v0 = "Ders İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Lesson/LessonGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLessonDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateLesson/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLessonDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Lesson/UpdateLesson", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Lesson", new { area = "Director" });
            }

            return View();
        }
    }
}
