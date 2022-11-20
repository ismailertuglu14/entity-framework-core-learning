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
/*
var urunSayisi = (await context.Urunler.CountAsync());
Console.Write(urunSayisi);
*/
#endregion

/* */
#region Sorgu sonucu Dönüşüm Fonksiyonları

#region ToDictionaryAsync
// Key, value
// var urunler = await context.Urunler.ToDictionaryAsync(urun => urun.UrunAdi, urun=>urun.Fiyat);
// ToList: Gelen sorguyu entity türünde bir koleksiyonda ( List<TEntity> ) Dönüştürmekteyken,
// ToDictionary: Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
#endregion
#region ToArrayAsync
// Oluşturulan sorguyu dizi olarak elde eder.
// ToList ile muadil amaca hizmet eder. Sorguyu execute eder Lakin gelen sonucu entity dizisi olarak elde eder.
// var urunler = context.Urunler.ToArrayAsync();

#endregion
#region Select Komutu
// Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudr.
// Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır.
// Lüzumsuz kolonları istemediğimi söylüyoruz ve o kolonlar bize null geliyor.
/*
var urunler = await context.Urunler.Select(urun => new Urun
{
    Id = urun.Id,
    Fiyat = urun.Fiyat
}).ToListAsync();
*/

// 2. olarak Select fonksiyonu gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim
// Anonim tür olduğu için artık gereksiz kolonlar gelmemiş olacak.
/*
  var urunler = await context.Urunler.Select(urun => new
{
    Id = urun.Id,
    Fiyat = urun.Fiyat
}).ToListAsync();
*/
/*
  var urunler = await context.Urunler.Select(urun => new UrunDetay
{
    Id = urun.Id,
    Fiyat = urun.Fiyat
}).ToListAsync();
*/

/********* *********/
#region Select Many
// İlişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.
/*
var urunler = await context.Urunler.Include(urun => urun.Parcalar).SelectMany(urun => urun.Parcalar, (urun,parca)=> new {
urun.Id,
urun.Fiyat,
parca.ParcaAdi
}).ToListAsync();
*/
#endregion

#endregion

#endregion

#region GroupBy Fonksiyonu
// Gruplama yapmamızı sağlayan fonksiyondur.
/*
var datas = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
{
    Count = group.Count(),
    Fiyat = group.Key
}).OrderByDescending(u=>u.Count).ToListAsync();
*/
// QUery Syntax
/*
var datas2 = await (from urun in context.Urunler
            group urun by urun.Fiyat
            into g
            select new
            {
                Fiyat = g.Key,
                Count = g.Count()
            }).ToListAsync();
*/
#endregion

#region ForEach
// Bir sorgulama fonksiyonu felan değildir!
// datas.ForEach(x => Console.Write(x.Count));

#endregion

#endregion

/* ******************* Change Tracker ***************************** */

#region ChangeTracker Derinlemesine

/* 
    Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler.
İşte bu Takip mekanizmasına ChangeTracker denir. Change Tracker ile nesneler üzerindeki değişikler ya da işlemler
takip edilerek netice itibariyle bu işlemlerin fıtratına uygun sql sorgucukları generate edilir. BU işleme Change Tracking denir.
*/

#region ChangeTracker Propertysi
// Takip edilen neselere erişebilmemizi ve gerektiği taktirde işlemler gerçekleştirmemizi sağlayan bir properytdir.    
// Context sınıfının base class'ı olan Dbcontext sınıfının bir member'ıdır
/*
var urunler = await context.Urunler.ToListAsync();
urunler[6].Fiyat = 123;
context.Urunler.Remove(urunler[7]);
urunler[8].UrunAdi = "asdasd";
var datas3 = context.ChangeTracker.Entries();
*/
#endregion
#region DetectChanges Metodu
/*
 * EFCore context Nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel değişikler yakalanarak
 * bunların anlık görüntüleri (snapshot) oluşturulabilir.
 * Yapılan değişikliklerinn veritabanına gönderilmeden önce algılandığından emin olmak gerekir. Save Changes fonksiyonu çağırıldığı anda nesneler EFCore tarafından otomatik
 * kontrol edilirler. (SaveChanges zaten öncesidnde bir detect yapıyomuş yani. Bunun farkında olmak lazım) 
 * Ancak Yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişiklerin algılanmasını opsiyonel olarak gerçekleştirmek isteyebiliriz.
 * İşte bunun için DetectChanges fonksiyonu kullanılabilir ve her ne kadar EFCore değişiklikleri otomatik algılıyor olsada siz yinede iradenizle kontrole zorlayabilirsiniz.
 */
/*
var datas5 = await context.Urunler.ToListAsync();
datas5[0].Fiyat = 30;
context.ChangeTracker.DetectChanges(); // lüzumsuz maaliyet şu aşamada.
await context.SaveChangesAsync();
*/
#endregion

#region Entries methodu
/*
 * Contex'te ki Entry metodunun koleksiyonel versiyonudur.
 * ChangeTracker mekanizması tarafından izlenen her entity nesnesinin bilgisini EntityEntry türünden elde etmemizi
 * sağlar ve belirli işlemler yapabilmemize olanak tanır.
 * Entries metodu, DetectChanges methodunu tetikler. Bu durum da tıpkı SaveCHanges da olduğu gibi bir maaliyettir. 
 * Buradaki maaliyetten kaçınmak için AutoDetectChangesEnabled özelliğine false değeri verilebilir.
 */
/*
var urunler10 = await context.Urunler.ToListAsync();
urunler10.FirstOrDefault(u => u.Id == 18).Fiyat = 120;
context.ChangeTracker.Entries().ToList().ForEach(e =>
{
    if(e.State == EntityState.Unchanged)
    {
        //..
    }else if(e.State == EntityState.Deleted)
    {
        // ...
    }
});
*/

#endregion
#region HasChanges methodu
/*
 * Takip edilen nesneler arasından değişiklik yapılanların olup olmadığının bilgisini verir.
 * !! Arkaplanda DetectChanges methodunu tetikler.
 */
// var result = context.ChangeTracker.HasChanges();
// resultun tipi bool dur.

#endregion

// Entity States
#region Entity States
// Entity nesnelerinin durumlarını ifade eder.
#region Detached
/*
 * Nesnenin change tracker mekanizması tarafından takip edilmediğini ifade eder.
 */
//Urun urun = new (); // BU ürün context üzerindne gelmediği için takip edilmiyor o yüzden State durumuna detached diyecektir.
// Nesnenin state ini verir consola loglayabiliriz.
//Console.Write(context.Entry(urun).State); // Detached

#endregion
#region Added
/* Veritabanına eklenecek nesneyi ifade eder.
 * Ama henüz veritabanına işlenmeyen veriyi ifade eder.
 * SaveChanges fonksyionu çağrıldığında insert sorgusu oluşturulacağı anlamına gelir.
 
Urun urun = new()
{
    Fiyat = 123,
    UrunAdi = "asdsad"
};

Console.Write(context.Entry(urun).State);// Detached
await context.Urunler.AddAsync(urun);
//Bu noktada artık bu ürünü context takibi yapacak bu ürünü
Console.Write(context.Entry(urun).State); // Added
await context.SaveChangesAsync();
*/
#endregion


#endregion

#region Change Tracker'ın Interceptor olarak kullanılması
/*
 * 
 */
#endregion

#region Context Nesnesi üzerinden Change Tracker
var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55);
urun.Fiyat = 213213; // Modified yapıldı.

#region OriginalValues Property'si
/*
 Veritabanındaki orjinal fiyat bilgisini verir bize.
var fiyat = context.Entry(urun).OriginalValues.GetValue<float>(nameof(Urun.Fiyat));
Console.Write(fiyat);
*/
#endregion
#region CurrentValues Property'si
/*
 Entity nin güncel verileri almak istersek kullanıyoruz.
var urunAdi = context.Entry(urun).CurrentValues.GetValue<string>(nameof(urun.UrunAdi));
Console.WriteLine(urunAdi);
*/
#endregion


#endregion
#endregion


// For Debugging
Console.WriteLine();


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

    // Change Tracker'ın Interceptor olarak kullanılması
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();
        foreach(var entry in entries)
        {
            if(entry.State == EntityState.Added)
            {
                /* 
                 * Db ye gitmeden önce araya girebiliriz burada.
                 */
                
            }
        }
        return base.SaveChangesAsync(cancellationToken);
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

public class UrunDetay
{
    public int? Id { get; set; }
    public float Fiyat { get; set; }
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
