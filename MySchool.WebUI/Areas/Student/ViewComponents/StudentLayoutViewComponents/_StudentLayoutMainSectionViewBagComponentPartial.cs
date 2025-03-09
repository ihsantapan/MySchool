using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Student.ViewComponents.StudentLayoutViewComponents
{
    public class _StudentLayoutMainSectionViewBagComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
