using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.TeacherDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Admin.Controllers
{

    [Area("Director")]
    [Route("Director/Teacher")]
    public class TeacherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeacherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğretmenler";
            ViewBag.v3 = "Öğretmen Listesi";
            ViewBag.v0 = "Öğretmen İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44391/api/Teacher/TeacherList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeacherDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateTeacher")]
        public IActionResult CreateTeacher()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğretmenler";
            ViewBag.v3 = "Öğretmen Girişi";
            ViewBag.v0 = "Öğretmen İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateTeacher")]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDto createTeacherDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeacherDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Teacher/CreateTeacher", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Teacher", new { area = "Director" });
            }

            return View();
        }

        [Route("DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Teacher/DeleteTeacher?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Teacher", new { area = "Director" });
            }
            return View();
        }

        [Route("UpdateTeacher/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateTeacher(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öğretmenler";
            ViewBag.v3 = "Öğretmen Güncelleme Sayfası";
            ViewBag.v0 = "Öğretmen İşlemleri";

            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Teacher/TeacherGetById?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeacherDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateTeacher/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDto updateTeacherDto)
        {          
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeacherDto);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Teacher/UpdateTeacher", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Teacher", new { area = "Director" });
            }

            return View();
        }

    }
}
