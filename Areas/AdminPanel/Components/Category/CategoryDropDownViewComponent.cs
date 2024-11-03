using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using Vektorel_234_CRM.Helper.Const;
using Vektorel_234_CRM.Helper.Result;
using Vektorel_234_CRM.Helper.SessionHelper;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Category;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Group;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Components.Category
{
    public class CategoryDropDownViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Guid? productCategoryGuid, string ddlID)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/Categories";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<CategoryDTO>>>(response.Content);

            var categoryList = responseObject.Data;

            CategoryDropDownViewModel categoryDropDownViewModel = new CategoryDropDownViewModel();

            categoryDropDownViewModel.CategoryList = categoryList;
            categoryDropDownViewModel.ProductCategoryGUID = productCategoryGuid == Guid.Empty ? null : productCategoryGuid;
            categoryDropDownViewModel.ddlCateogryElementID = ddlID;

            return View("~/Areas/AdminPanel/Views/Shared/Component/Category/CategoryDropDown.cshtml", categoryDropDownViewModel);
        }
    }
}

