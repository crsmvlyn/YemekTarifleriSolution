using System.Collections.Generic;

namespace YemekTarifleriApp.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        // DİKKAT: Tarifler listesinin sonuna ? koyduk.
        // Bu "Listenin boş olması sorun değil" demektir.
        public ICollection<Tarif>? Tarifler { get; set; }
    }
}