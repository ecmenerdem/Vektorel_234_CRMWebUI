namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Product
{
    public class AddProductDTORequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryGUID { get; set; }

        public string ProductImage { get; set; }
    }
}
