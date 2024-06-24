using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutHeadComponent:ViewComponent
    { 
       public IViewComponentResult Invoke() { return View(); }
    }
}
