using Microsoft.AspNetCore.Mvc;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        [HttpGet("/Admin/InvokeCategoryDropDown")]
        public IActionResult InvokeCategoryDropDown(Guid? productCategoryGuid, string ddlID)
        {
            return ViewComponent("CategoryDropDown", new { productCategoryGuid, ddlID });
        }
    }
}
