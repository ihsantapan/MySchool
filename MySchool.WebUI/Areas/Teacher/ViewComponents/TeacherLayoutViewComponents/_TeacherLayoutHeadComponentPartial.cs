using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Teacher.ViewComponents.TeacherLayoutViewComponents
{
    public class _TeacherLayoutHeadComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
