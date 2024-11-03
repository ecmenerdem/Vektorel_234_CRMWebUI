using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using Vektorel_234_CRM.Helper.Const;
using Vektorel_234_CRM.Helper.DTO.Login;
using Vektorel_234_CRM.Helper.Result;
using Vektorel_234_CRM.Helper.SessionHelper;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.User;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        [HttpGet("/Admin/Kullanicilar")]
       public async Task<IActionResult> Users()
        {
            var url =ApiEndpoint.ApiEndpointURL+"/Users";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer "+SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<UserDTO>>>(response.Content);

            var userList = responseObject.Data;

            return View(userList);
        }


        [HttpGet("/Admin/Kullanici/{userGUID}")]
        public async Task<IActionResult> GetUser(Guid userGUID)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/User/"+ userGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<UserDTO>>(response.Content);

            var user = responseObject.Data;

            return Json(user);

        }


        [ValidateAntiForgeryToken]
        [HttpPost("/Admin/UpdateUser")]
        public async Task<IActionResult>UpdateUser(UserUpdateRequestDTO updateUserDTO)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/User/";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);
            request.AddBody(JsonSerializer.Serialize(updateUserDTO));

            RestResponse response = await client.ExecuteAsync(request);

         

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var responseObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);
                return Json(new {success=true});
            }

            var responseErrorObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);
            return Json(new { success = false, hataAciklama = responseErrorObject.HataBilgisi.HataAciklama[0] });

        }

        [ValidateAntiForgeryToken]
        [HttpPost("/Admin/AddUser")]
        public async Task<IActionResult>AddUser(UserAddRequestDTO userAddRequestDTO)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/User/";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);


            request.AddHeader("Authorization", "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJBZCI6IkVjbWVuZSIsIlNveWFkIjoiRXJkZW0iLCJLdWxsYW5pY2lBZGkiOiJlY21lbiIsImV4cCI6MjY3NjcxNjc5OSwiaXNzIjoiaHR0cHM6Ly9hc2Rhc2RkYXNkYXMuY29tIn0.He-DnvFgGCcvWaQDqcXWdl0gccCCQpyT1v5hMzVWID8");

            request.AddBody(JsonSerializer.Serialize(userAddRequestDTO));

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var responseObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);
                return Json(new {success=true});
            }

            var responseErrorObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);
            return Json(new { success = false, hataAciklama= responseErrorObject.HataBilgisi.HataAciklama[0] });

        }
    }
}
