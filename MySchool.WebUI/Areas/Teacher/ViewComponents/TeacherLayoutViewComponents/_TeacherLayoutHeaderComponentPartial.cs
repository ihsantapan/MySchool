using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Teacher.ViewComponents.TeacherLayoutViewComponents
{
    public class _TeacherLayoutHeaderComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
