namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.Group
{
    public class GroupDropDownViewModel
    {
        public List<GroupResponseDTO> GroupList { get; set; }
        public Guid? UserGroupGuid { get; set; }

        public string ddlGroupID { get; set; }
    }
}
