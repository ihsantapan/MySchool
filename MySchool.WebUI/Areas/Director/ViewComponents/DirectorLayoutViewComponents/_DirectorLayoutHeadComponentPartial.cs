using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _DirectorLayoutHeadComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
