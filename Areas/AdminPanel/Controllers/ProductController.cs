using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Text.Json;
using Vektorel_234_CRM.Helper.Const;
using Vektorel_234_CRM.Helper.Result;
using Vektorel_234_CRM.Helper.SessionHelper;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Product;
using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.User;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("/Admin/Urunler")]
        public async Task<IActionResult> Index()
        {
            var url = ApiEndpoint.ApiEndpointURL + "/Products";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<List<ProductDTO>>>(response.Content);

            var productList = responseObject.Data;

            //throw new Exception();
            // Test amaçlı yazıldı
            return View(productList);

        }

        [HttpPost("/Admin/UrunEkle")]
        public async Task<IActionResult> Add(AddProductDTORequest productDTO, IFormFile productImage)
        {
            if (productImage is not null)
            {
                string fileName = productImage.FileName.Split('.')[productImage.FileName.Split('.').Length - 2] +"_"+Guid.NewGuid()+"."+productImage.FileName.Split('.')[productImage.FileName.Split('.').Length-1];

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "MediaUpload", fileName);

                using (var filestream  = new FileStream(uploadFolder,FileMode.Create))
                {
                    productImage.CopyTo(filestream);
                }
                productDTO.ProductImage = fileName;
            }
            
            


            var url = ApiEndpoint.ApiEndpointURL + "/Product";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);
            request.AddBody(productDTO);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);

            var result = responseObject.Data;

            if (response.StatusCode==HttpStatusCode.OK)
            {
                return Json(new {success=true});
            }

            return Json(new { success = false });

        }
        
        [HttpPost("/Admin/UrunGuncelle")]
        public async Task<IActionResult> Update(UpdateProductDTORequest productDTO, IFormFile productImage)
        {
            if (productImage is not null)
            {
                string fileName = productImage.FileName.Split('.')[productImage.FileName.Split('.').Length - 2] +"_"+Guid.NewGuid()+"."+productImage.FileName.Split('.')[productImage.FileName.Split('.').Length-1];

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "MediaUpload", fileName);

                using (var filestream  = new FileStream(uploadFolder,FileMode.Create))
                {
                    productImage.CopyTo(filestream);
                }
                productDTO.ProductImage = fileName;
            }

            else
            {
                productDTO.ProductImage = null;
            }
            


            var url = ApiEndpoint.ApiEndpointURL + "/Product";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);
            request.AddBody(productDTO);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<bool>>(response.Content);

            var result = responseObject.Data;

            if (response.StatusCode==HttpStatusCode.OK)
            {
                return Json(new {success=true});
            }

            return Json(new { success = false });

        }


        [HttpGet("/Admin/Urun/{productGUID}")]
        public async Task<IActionResult> GetProduct(Guid productGUID)
        {
            var url = ApiEndpoint.ApiEndpointURL + "/Product/" + productGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.loginResponseDTO.Token);

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonSerializer.Deserialize<ApiResult<ProductDTO>>(response.Content);

            var product = responseObject.Data;

            return Json(product);

        }
    }
}
