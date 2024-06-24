using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutServiceComponent :ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
