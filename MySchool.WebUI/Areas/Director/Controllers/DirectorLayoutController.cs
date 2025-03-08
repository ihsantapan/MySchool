using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Admin.Controllers
{
    [Area("Director")]
    public class DirectorLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
