using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
