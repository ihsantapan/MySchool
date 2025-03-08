using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.ClassDtos;
using MySchool.FrontendDtoLayer.Dtos.TeacherDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Director.Controllers
{
    [Area("Director")]
    [Route("Director/Class")]
    public class ClassController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClassController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınıflar";
            ViewBag.v3 = "Sınıf Listesi";
            ViewBag.v0 = "Sınıf İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Class/ClassList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultClassDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateClass")]
        public IActionResult CreateClass()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınıflar";
            ViewBag.v3 = "Sınıf Girişi";
            ViewBag.v0 = "Sınıf İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateClass")]
        public async Task<IActionResult> CreateClass(CreateClassDto createClassDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createClassDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Class/CreateClass", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Class", new { area = "Director" });
            }

            return View();
        }

        [Route("DeleteClass/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Class/DeleteClass?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Class", new { area = "Director" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateClass/{id}")]
        public async Task<IActionResult> UpdateClass(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınıflar";
            ViewBag.v3 = "Sınıf Güncelleme Sayfası";
            ViewBag.v0 = "Sınıf İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Class/ClassGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateClassDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateClass/{id}")]
        public async Task<IActionResult> UpdateClass(UpdateClassDto updateClassDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateClassDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Class/UpdateClass", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Class", new { area = "Director" });
            }

            return View();
        }
    }
}
