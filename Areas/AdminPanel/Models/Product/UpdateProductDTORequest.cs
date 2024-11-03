using System.Text.Json.Serialization;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Product
{
    public class UpdateProductDTORequest
    {
        public Guid ProductGUID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryGUID { get; set; }

        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public string? ProductImage { get; set; }
    }
}
