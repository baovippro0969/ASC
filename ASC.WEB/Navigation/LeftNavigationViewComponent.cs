using ASC.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASC.WEB.Navigation
{
    [ViewComponent(Name = "ASC.Web.Navigation.LeftNavigation")]
    public class LeftNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(NavigationMenu menu)
        {
            menu.MenuItems = menu.MenuItems.OrderBy(p => p.Sequence).ToList();
            return View(menu);
        }
    }
}
