using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Director.ViewComponents.DirectorLayoutViewComponents
{
    public class _DirectorLayoutMainSectionViewBagComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
