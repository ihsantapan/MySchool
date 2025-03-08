using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.StudentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Director.Controllers
{
    [Area("Director")]
    [Route("Director/Student")]
    public class StudentController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğrenciler";
            ViewBag.v3 = "Öğrenci Listesi";
            ViewBag.v0 = "Öğrenci İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Student/StudentList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStudentDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateStudent")]
        public  IActionResult CreateStudent()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğrenciler";
            ViewBag.v3 = "Öğrenci Girişi";
            ViewBag.v0 = "Öğrenci İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentDto createStudentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createStudentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Student/CreateStudent", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Student", new { area = "Director" });
            }

            return View();
        }

        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Student/DeleteStudent?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Student", new { area = "Director" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğrenciler";
            ViewBag.v3 = "Öğrenci Güncelleme Sayfası";
            ViewBag.v0 = "Öğrenci İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Student/StudentGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStudentDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto updateStudentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStudentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Student/UpdateStudent", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Student", new { area = "Director" });
            }

            return View();
        }
    }
}
