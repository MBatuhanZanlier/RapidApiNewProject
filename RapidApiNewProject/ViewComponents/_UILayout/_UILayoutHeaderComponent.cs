using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutHeaderComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
