using Microsoft.EntityFrameworkCore;
using YemekTarifleriApp.Models;

namespace YemekTarifleriApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Veritabanındaki tablolarımız bunlar olacak
        public DbSet<Tarif> Tarifler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}