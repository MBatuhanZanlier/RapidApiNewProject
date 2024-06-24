using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutScriptComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
