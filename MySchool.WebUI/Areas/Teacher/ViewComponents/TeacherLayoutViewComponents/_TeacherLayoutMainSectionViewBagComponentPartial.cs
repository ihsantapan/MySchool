using Microsoft.AspNetCore.Mvc;

namespace MySchool.WebUI.Areas.Teacher.ViewComponents.TeacherLayoutViewComponents
{
    public class _TeacherLayoutMainSectionViewBagComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
