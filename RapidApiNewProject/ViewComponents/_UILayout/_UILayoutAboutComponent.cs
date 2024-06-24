using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutAboutComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
