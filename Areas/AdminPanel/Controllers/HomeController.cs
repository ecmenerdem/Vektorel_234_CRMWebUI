using Microsoft.AspNetCore.Mvc;
using Vektorel_234_CRM.Helper.SessionHelper;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
