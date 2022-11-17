using System.Text;
using Microsoft.EntityFrameworkCore;


//
ETicaretContext context = new();
#region
/*Urun urun = new Urun()
{
    Id=1123,
    Fiyat = 1000,
    UrunAdi = "A ürünü"
};
*/
//await context.Urunler.AddAsync(urun);


//await context.SaveChangesAsync();

#region Eklenen verinin State durumunu görmek
/*
Urun urun2 = new()
{
    UrunAdi = "B ürünü",
    Fiyat = 3000
};
Console.WriteLine(context.Entry(urun2).State);
await context.AddAsync(urun2);
Console.WriteLine(context.Entry(urun2).State);

//await context.SaveChangesAsync();*/
#endregion
#region Birden fazla veri eklerken nelere dikkat edilmeli  SaveChanges verimli kullanılmalı
/*Urun urun1 = new()
{
    UrunAdi = "A ürünü",
    Fiyat = 3000
};
Urun urun2 = new()
{
    UrunAdi = "B ürünü",
    Fiyat = 3000
};
Urun urun3 = new()
{
    UrunAdi = "C ürünü",
    Fiyat = 3000
};
await context.AddAsync(urun1);
await context.AddAsync(urun2);
await context.AddAsync(urun3);
await context.SaveChangesAsync();*/
#endregion
#region AddRange
/*Urun urun1 = new()
{
    UrunAdi = "A ürünü",
    Fiyat = 3000
};
Urun urun2 = new()
{
    UrunAdi = "B ürünü",
    Fiyat = 3000
};
Urun urun3 = new()
{
    UrunAdi = "C ürünü",
    Fiyat = 3000
};
await context.Urunler.AddRangeAsync(urun1,urun2,urun3);
await context.SaveChangesAsync();*/
#endregion
#region Eklenen verinin Generate Edilen ID'sini getirme
/*
 Urun urun = new()
{
    UrunAdi = "Test ürünü",
    Fiyat = 1500
};
await context.AddAsync(urun);
await context.SaveChangesAsync();
Console.WriteLine(urun.Id);

 */
#endregion
/* Ders 11 Veri Güncelleme */
#region Veri nasıl güncellenir ?
/*
Urun urun = await context.Urunler.FirstOrDefaultAsync(urun=>urun.Id == 3 );
urun.UrunAdi = "Telefon ürünü";
urun.Fiyat = 9500;
await context.SaveChangesAsync();
Console.WriteLine(urun.UrunAdi);
*/
#endregion
#region ChangeTracker nedir?
// Change tracker context üzerinden gelen verilerin takibinden sorumlu mekanizmadır.
// Bu takip mekanizması sayesinde context üzerinden gelen veriler ile ilgili işlemler neticesinde
//update yahut delete sorgularının oluşturulacağı anlaşılır.


#endregion
#region Takip Edilmeyen Nesneler Nasıl Güncellenir? With Update Fonksiyonu
/*
Urun urun = new()
{
    Id = 3,
    UrunAdi = "Yeni Ürün",
    Fiyat = 3333
};

// Update fonksiyonu
// Kesinlikle urun entitysinde Id bilgisi verilmeli.
context.Urunler.Update(urun);
await context.SaveChangesAsync();
*/
#endregion
#region EntityState nedir?
/* Bir Entity instance ının durumunu ifade eden bir referanstır  */
#endregion
#region Birden fazla ürün güncellemek istersek nelere dikkat etmeliyiz?
/*
var urunler = await context.Urunler.ToListAsync();
foreach(var urun in urunler)
{
    urun.UrunAdi = urun.Id + " - " + urun.UrunAdi;
}
await context.SaveChangesAsync();
 */
#endregion
/****************************** Ders 12 Veri Silme **********************************************/
#region Veri silme
/*
Urun silinecekUrun = await context.Urunler.FirstOrDefaultAsync(urun => urun.Id == 5);
context.Urunler.Remove(silinecekUrun);
await context.SaveChangesAsync();
*/
#endregion
#region Takip edilemeyen nesneler nasıl silinir?
/*
  Urun urun10 = new()
{
    Id = 2
};
context.Urunler.Remove(urun10);
await context.SaveChangesAsync();
*/
#endregion
#region EntityState ile silme işlemi
/*
Urun u = new() { Id = 1 };
context.Entry(u).State = EntityState.Deleted;
await context.SaveChangesAsync();
*/
#endregion

#region Toplu ürün silme with RemoveRange
/*
List<Urun> urunler = await context.Urunler.Where(urun => urun.Id >= 7 && urun.Id <=9).ToListAsync();
context.Urunler.RemoveRange(urunler);
await context.SaveChangesAsync();
*/
#endregion
#endregion
/* *********************************** Sorgulama Yapılanmaları ********************************/
#region

#region method syntax

// sorgulama yaparken methodları kullanıyorsak bua method syntax diyoruz.
//var urunler = await context.Urunler.ToListAsync();

#endregion

#region query syntax

//var urunler2 = await (from urun in context.Urunler select urun).ToListAsync();

#endregion

#region  ForEach ile sorguları execute etme
/*
var urunler = from urun in context.Urunler select urun;
foreach (var urun in urunler)
{
    Console.Write(urun.UrunAdi);
}
*/
#endregion

#region where
/*
var urunler = await context.Urunler.Where(urun => urun.Id > 2).ToListAsync();
foreach (var item in urunler)
{
    Console.WriteLine(item.Fiyat);
}
*/
#endregion
/* ************************ Tekil veri getirenler ********************* */

#region SingleAsync
/*
var urun = await context.Urunler.SingleAsync(u => u.Id == 6);
Console.WriteLine(urun.UrunAdi);
*/
#endregion
#region SingleOrDefault
/*
var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 66);
Console.WriteLine(urun?.UrunAdi);
*/
#endregion
#region FindAsync
/*
  
Urun urun = await context.Urunler.FindAsync(5);
Console.Write(urun.Fiyat);

*/
/*
UrunParca? urun = await context.UrunParca.FindAsync(2,5);
Console.Write(urun?.Urun.UrunAdi);*/
#endregion

/*********************** Diğer sorgulama fonksiyonları *******************/
#region CountAsync

var urunSayisi = (await context.Urunler.CountAsync());
Console.Write(urunSayisi);

#endregion
#endregion

public class ETicaretContext : DbContext
{

    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar{ get; set; }
    public DbSet<UrunParca> UrunParca { get; set; }
         
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=ismailei123;Host=localhost;Port=5432;Database=ETicaretDB");
    }
    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
    }

}


public class Urun
{
    public int? Id { get; set; }
    public string? UrunAdi { get; set; }
    public float Fiyat { get; set; }

    public ICollection<Parca> Parcalar { get; set; }

}
public class Parca
{
    public int? Id { get; set; }
    public string ParcaAdi { get; set; }

}

public class UrunParca
{
    public int? UrunId { get; set; }
    public int? ParcaId { get; set; }

    public Urun? Urun { get; set; }
    public Parca? Parca { get; set; }
}

#region OnConfiguring
/*------------ OnConfiguring -------------
 * 
 * EFCore tool'unu yapılandırmak için kullanılan bir metoddur.
 * Context nesnesinde override edilerek kullanılır.
 * 
 */
#endregion

#region Basit Düzeyde Entity Tanımlama Kuralları
/*
 * EFCore her tablonun default olarak bir primary key kolonu olması gerektiğini kabul eder!
 * 
 * 
 */
#endregion
