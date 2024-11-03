using Microsoft.AspNetCore.Mvc;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class GroupController : Controller
    {

        [HttpGet("/Admin/InvokeGroupDropDown")]
        public IActionResult InvokeGroupDropDown(Guid? userGroupGuid, string ddlID)
        {
            return ViewComponent("GroupDropDown", new { userGroupGuid, ddlID });
        }
    }
}
