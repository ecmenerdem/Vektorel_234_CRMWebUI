using Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Group;

namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Category
{
    public class CategoryDropDownViewModel
    {
        public List<CategoryDTO> CategoryList { get; set; }
        public Guid? ProductCategoryGUID { get; set; }

        public string ddlCateogryElementID { get; set; }
    }
}
