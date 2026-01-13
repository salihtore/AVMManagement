# AVM Yönetim Sistemi - Proje Sunum Raporu

**Tarih:** 09.01.2026
**Durum:** Tamamlandı / Yayına Hazır

---

## 1. Proje Özeti
AVM Yönetim Sistemi, alışveriş merkezlerinin idari, finansal ve operasyonel süreçlerini tek bir merkezden yönetmelerini sağlayan kapsamlı bir masaüstü yazılımıdır. Proje, AVM yönetiminin, mağaza kiracılarının ve personellerin ihtiyaçlarına yönelik modüler bir yapıda geliştirilmiştir.

## 2. Teknik Mimari
Proje, endüstri standartlarına uygun, ölçeklenebilir ve n-katmanlı (N-Layered) bir mimari ile geliştirilmiştir.

*   **Dil ve Platform:** C# / .NET Framework (Windows Forms)
*   **Arayüz Teknolojisi:** DevExpress UI Kütüphanesi (Modern ve kullanıcı dostu arayüzler için)
*   **Veritabanı:** Microsoft SQL Server
*   **ORM (Veri Erişimi):** Entity Framework 6 (Code-First Yaklaşımı)
*   **Tasarım Desenleri:**
    *   *Repository Pattern:* Veri erişiminin soyutlanması.
    *   *Unit of Work Pattern:* İşlemlerin toplu ve güvenli (transactional) yönetilmesi.

---

## 3. Modüller ve Özellikler

Sistem, kullanıcı rollerine göre ayrıştırılmış üç ana panelden oluşur:

### A. Yönetici Paneli (Admin Dashboard)
AVM'nin genel yönetiminin yapıldığı, tüm yetkilere sahip paneldir.
1.  **Ana Sayfa:** Doluluk oranları, bekleyen talepler ve günlük ciro özetini gösteren yönetici panosu.
2.  **Mağaza Yönetimi:** Mağazaların kat bilgileri, metrekareleri ve kategorilerine göre listelenmesi.
3.  **Kiracı ve Sözleşme Yönetimi:**
    *   Kiracı firmaların vergi ve iletişim bilgileri.
    *   Kira sözleşmelerinin (Başlangıç/Bitiş Tarihi, Bedel) takibi ve depozito yönetimi.
4.  **Finansal Yönetim:**
    *   *Kira Ödemeleri:* Mağazaların ödeme durumlarının takibi.
    *   *Gider Yönetimi:* AVM ortak giderlerinin kaydı.
    *   *Ciro Takibi:* Mağazaların girdiği günlük ciroların raporlanması.
5.  **İnsan Kaynakları:** Tüm AVM ve mağaza personellerinin tek havuzda görüntülenmesi.
6.  **Talep Yönetimi:**
    *   *Teknik Servis:* Mağazalardan gelen arıza/destek taleplerinin karşılanması.
    *   *İzin Yönetimi:* AVM personellerinin izin taleplerinin onaylanması.
7.  **Duyurular:** Tüm sisteme veya belirli gruplara duyuru yayınlama.

### B. Mağaza Paneli (Tenant Dashboard)
Mağaza müdürlerinin kendi operasyonlarını yürüttüğü paneldir.
1.  **Kendi Personelleri:** Sadece kendi mağazasında çalışanları görme ve yönetme.
2.  **Ciro Girişi:** Günlük hasılatın sisteme girilmesi.
3.  **Talep Oluşturma:**
    *   *Arıza Bildirimi:* AVM yönetimine "Klima arızası", "Temizlik" gibi taleplerin iletilmesi.
    *   *İzin Talebi:* Kendi personeli için izin taleplerinin sisteme girilmesi veya onaylanması.

### C. Personel Paneli
Bireysel çalışanların (Güvenlik, Temizlik) sisteme giriş yaptığı kısıtlı ekran.
*   Kendi vardiya bilgilerini görüntüleme.
*   Kendisine atanan görevleri (Devriye, Temizlik vb.) takip etme.

---

## 4. İş Akışları (Business Logic)
Proje, sadece veri tutmanın ötesinde operasyonel iş akışlarını otomatikleştirir:
*   **Dinamik Giriş:** Kullanıcı rolüne (Admin/Mağaza) göre otomatik olarak doğru panele yönlendirilir. Mağaza kullanıcıları sadece yetkili oldukları mağazanın verilerine erişebilir.
*   **İzin Onay Mekanizması:** Bir mağaza personelinin izin talebi sistemde kayıt altına alınır ve reddedilirse sebebiyle birlikte saklanır.
*   **Veri Bütünlüğü:** Code-First yaklaşımı sayesinde veritabanı şeması ve yazılım sınıfları her zaman senkronize çalışır.

## 5. Kullanıcı Deneyimi (UX)
*   **Modern Arayüz:** Standart Windows formları yerine DevExpress bileşenleri kullanılarak "Premium" bir görünüm elde edilmiştir.
*   **Hız ve Erişim:** "Accordion" menü yapısı ile modüller arasında hızlı geçiş imkanı sağlanmıştır.

## 6. Özet
Bu proje, bir AVM'nin karmaşık yönetim süreçlerini (Kira, Personel, Teknik Servis) dijitalleştirerek şeffaf, ölçülebilir ve yönetilebilir bir yapıya kavuşturmuştur. Hem teknik altyapısı hem de kullanıcı odaklı tasarımı ile gerçek hayatta kullanıma uygun, sağlam bir temel üzerindedir.
