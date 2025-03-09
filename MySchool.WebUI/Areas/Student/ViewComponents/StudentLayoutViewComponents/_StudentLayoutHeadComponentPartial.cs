using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Student.ViewComponents.StudentLayoutViewComponents
{
    public class _StudentLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
