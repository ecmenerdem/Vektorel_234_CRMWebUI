using Microsoft.AspNetCore.Mvc;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutController : Controller
    {
        [HttpGet("/Admin/Hakkimizda")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
