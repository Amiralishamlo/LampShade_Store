using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
