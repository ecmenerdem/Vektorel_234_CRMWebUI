using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using Vektorel_234_CRM.Helper.Const;
using Vektorel_234_CRM.Helper.Result;
using Vektorel_234_CRM.Helper.SessionHelper;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Group;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.User;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Components.Group
{
    public class GroupDropDownViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync(Guid? userGroupGuid, string ddlID)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/Groups";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<GroupResponseDTO>>>(response.Content);

            var groupList = responseObject.Data;

            GroupDropDownViewModel groupDropDownViewModel = new GroupDropDownViewModel();

            groupDropDownViewModel.GroupList = groupList;
            groupDropDownViewModel.UserGroupGuid = userGroupGuid == Guid.Empty?null: userGroupGuid;
            groupDropDownViewModel.ddlGroupID= ddlID;

            return View("~/Areas/AdminPanel/Views/Shared/Component/Group/GroupDropDown.cshtml", groupDropDownViewModel);
        }
    }
}
