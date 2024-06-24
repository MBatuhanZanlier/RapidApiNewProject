using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutFooterComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
