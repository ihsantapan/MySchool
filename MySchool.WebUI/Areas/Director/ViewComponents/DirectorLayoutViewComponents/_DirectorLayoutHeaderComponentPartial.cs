using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Director.ViewComponents.DirectorLayoutViewComponents
{
    public class _DirectorLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
