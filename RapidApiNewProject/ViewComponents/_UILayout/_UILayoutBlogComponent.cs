﻿using Microsoft.AspNetCore.Mvc;

namespace RapidApiNewProject.ViewComponents._UILayout
{
    public class _UILayoutBlogComponent:ViewComponent
    { 
        public IViewComponentResult Invoke() { return View(); }
    }
}
