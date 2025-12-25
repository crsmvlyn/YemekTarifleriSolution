namespace YemekTarifleriApp.Models
{
    public class Tarif
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        // Bunları da ? yapalım ki boş geçersen hata vermesin
        public string? Malzemeler { get; set; }
        public string? Yapilis { get; set; }
        public string? ResimUrl { get; set; }

        public int KategoriId { get; set; }

        // DİKKAT: Kategori nesnesinin sonuna ? koyduk.
        public Kategori? Kategori { get; set; }
    }
}