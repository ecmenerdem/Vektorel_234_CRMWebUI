namespace Vektorel_234_CRMWebUI.Areas.AdminPanel.Models.User
{
    public class UserDTO
    {
        public Guid? GUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }

        public string GrupAdi { get; set; }
        public Guid? GrupGUID { get; set; }
    }
}
