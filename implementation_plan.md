# Refactoring Planı: Veri Erişimi ve Performans Optimizasyonu

**Hedef:** İşlem bütünlüğünü (transaction) sağlamak için hatalı UnitOfWork desenini düzeltmek ve filtrelemeyi veritabanı tarafına taşıyarak (IQueryable) performansı optimize etmek.

## Kullanıcı Onayı Gerekli
> [!NOTE]
> Güvenlik düzeltmeleri (açık metin şifreler), kullanıcının talebi üzerine kapsam dışı bırakılmıştır.

## Önerilen Değişiklikler

### Veri Erişim Katmanı (AVM.DataAccess)
Tek bir DbContext paylaşacak şekilde veri erişim şablonlarını yeniden yapılandıracağız.

#### [DEĞİŞTİR] [IRepository.cs](file:///c:/Users/ASUS/source/repos/AVMManagement/AVM.DataAccess/Interfaces/IRepository.cs)
- `GetAll()` dönüş tipini `List<T>` yerine `IQueryable<T>` olarak değiştir.
- Bu, veriler belleğe gelmeden *önce* `Where`, `OrderBy` gibi sorguların zincirlenmesine olanak tanır.

#### [DEĞİŞTİR] [Repository.cs](file:///c:/Users/ASUS/source/repos/AVMManagement/AVM.DataAccess/Repositories/Repository.cs)
- Constructor içinden `new AVMContext()` kodunu kaldır.
- `DbContext` (veya `AVMContext`) kabul eden bir Constructor ekle.
- `GetAll` metodunu `_dbSet.AsQueryable()` döndürecek şekilde güncelle.
- Tekil CRUD metodlarından (`Add`, `Update`, `Delete`) `SaveChanges` çağrılarını kaldır. **Önemli:** `SaveChanges` sadece `UnitOfWork` tarafından çağrılmalı.

#### [DEĞİŞTİR] [UnitOfWork.cs](file:///c:/Users/ASUS/source/repos/AVMManagement/AVM.DataAccess/UnitOfWork.cs)
- Constructor içinde `AVMContext` örneğini bir kez oluştur.
- Bu örneği tüm Repository özelliklerine (property) parametre olarak geç.
- Context'i düzgün bir şekilde temizlemek için `IDisposable` uygula.
- `Save()` metodunun `_context.SaveChanges()` çağıran *tek* yer olduğundan emin ol.

### İş Katmanı (AVM.Business)
Yöneticileri yeni `IQueryable` gücünden yararlanacak şekilde güncelle.

#### [DEĞİŞTİR] [PersonnelManager.cs](file:///c:/Users/ASUS/source/repos/AVMManagement/AVM.Business/PersonnelManager.cs)
- `GetAll().ToList()` kullanımlarını kontrol et. Birçok durumda, ihtiyaç duyulana kadar sorgu olarak kalması için `.ToList()` kaldırılabilir.
- `Add/Update/Delete` çağrılarının ardından `_uow.Save()` geldiğinden emin ol (zaten öyleler, ama artık işlemsel olarak çalışacak).

#### [DEĞİŞTİR] [RentManager.cs](file:///c:/Users/ASUS/source/repos/AVMManagement/AVM.Business/RentManager.cs)
- `GetRentsByStore` ve `GetAllRentsDetailed` içindeki karmaşık birleştirmeler (join) şu anda TÜM tabloları RAM'e çekiyor.
- Bunları `IQueryable` kaynakları üzerinde LINQ Sorgu Sözdizimi kullanacak şekilde yeniden düzenle. Bu, 4 tabloyu tamamen çekmek yerine tek bir SQL Sorgusu üretecektir.

## Doğrulama Planı

### Manuel Doğrulama
1.  **Çözümü Derle (Build):** `List<T>` -> `IQueryable<T>` değişikliğinden sonra derleme hatası olmadığından emin ol.
2.  **Çalışma Zamanı Testi:** Uygulamayı çalıştır.
3.  **Performans Testi:** 'Duyurular' veya 'Kiralar' sayfalarını kontrol et. Çökmeden yüklenmeliler.
