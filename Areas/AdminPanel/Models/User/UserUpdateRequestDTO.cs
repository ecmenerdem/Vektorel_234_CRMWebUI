namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.User
{
    public class UserUpdateRequestDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public Guid GrupGUID { get; set; }
        public Guid UserGUID { get; set; }
    }
}
