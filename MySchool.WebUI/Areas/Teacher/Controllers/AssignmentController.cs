using Microsoft.AspNetCore.Mvc;
using MySchool.FrontendDtoLayer.Dtos.AssignmentDtos;
using MySchool.FrontendDtoLayer.Dtos.ExamDtos;
using Newtonsoft.Json;
using System.Text;

namespace MySchool.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("Teacher/Assignment")]
    public class AssignmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AssignmentController(IHttpClientFactory httpClientFactory)
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

        [HttpGet]
        [Route("CreateAssignment")]
        public IActionResult CreateAssignment()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ödevler";
            ViewBag.v3 = "Ödev Listesi";
            ViewBag.v0 = "Ödev İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateAssignment")]
        public async Task<IActionResult> CreateAssignment(CreateAssignmentDto createAssignmentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAssignmentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44391/api/Assignment/CreateAssignment", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Assignment", new { area = "Teacher" });
            }

            return View();
        }

        [Route("DeleteAssignment/{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44391/api/Assignment/DeleteAssignment?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Assignment", new { area = "Teacher" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateAssignment/{id}")]
        public async Task<IActionResult> UpdateAssignment(int id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Sınavlar";
            ViewBag.v3 = "Sınav Listesi";
            ViewBag.v0 = "Sınav İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44391/api/Assignment/AssignmentGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAssignmentDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateAssignment/{id}")]
        public async Task<IActionResult> UpdateAssignment(UpdateAssignmentDto updateAssignmentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAssignmentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44391/api/Assignment/UpdateAssignment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Assignment", new { area = "Teacher" });
            }

            return View();
        }
    }
}
