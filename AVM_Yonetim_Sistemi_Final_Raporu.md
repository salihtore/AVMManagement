# AVM Yönetim Sistemi - Final Proje Raporu

**Proje Adı:** AVM Yönetim Sistemi  
**Tarih:** 09.01.2026  

---

## PROJE MALİYET KESTİRİM DOKÜMANI

**1. İşlev Noktası Analizi (Function Point Analysis)**

| Ölçüm Parametresi | Sayı (Tahmini) | Ağırlık Faktörü | Toplam |
| :--- | :---: | :---: | :---: |
| Kullanıcı Girdi Sayısı (Login, Kayıt, Talep Ekleme vb.) | 15 | 3 | 45 |
| Kullanıcı Çıktı Sayısı (Raporlar, Grafikler, Faturalar) | 10 | 4 | 40 |
| Kullanıcı Sorgu Sayısı (Arama, Filtreleme) | 5 | 3 | 15 |
| Veri Tabanındaki Tablo Sayısı | 14 | 7 | 98 |
| Arayüz Sayısı (Formlar ve Kontroller) | 12 | 5 | 60 |
| **Ana İşlev Nokta Sayısı (AİN)** | | | **258** |

**2. Teknik Karmaşıklık Faktörü (TKF)**

*   *Hesaplanan Toplam Faktör:* 42 (Yedekleme: 3, Performans: 3, Kolay Kullanım: 5, Yeniden Kullanılabilirlik: 5, vb.)

**3. İşlev Noktası (İN) ve Satır Sayısı Hesabı**

*   **İN Formülü:** `AİN x (0.65 + 0.01 x TKF)`
*   **İN:** `258 x (0.65 + 0.42) = 258 x 1.07` = **276.06**
*   **Tahmini Satır Sayısı:** `276 x 30` = **8,280 Satır Kod (LOC)**

---

## 1. GİRİŞ

### 1.1. Projenin Amacı
Bu projenin temel amacı, büyük ölçekli Alışveriş Merkezlerinin (AVM) yönetim süreçlerini dijitalleştiren, merkezi ve modüler bir masaüstü yazılımı geliştirmektir. Sistem; mağaza kiralama, personel yönetimi, teknik servis talepleri ve finansal takibi tek bir platformda birleştirerek karar alma süreçlerini hızlandırmayı ve operasyonel verimliliği artırmayı hedefler.

### 1.2. Projenin Kapsamı
Proje, AVM Yönetimi, Mağaza Müdürü (Kiracı) ve Personel olmak üzere üç ana kullanıcı grubunu kapsar.
*   **Yönetim:** Kira sözleşmeleri, ciro takibi, personel atama, talep onayı.
*   **Kiracı:** Kendi personelini yönetme, arıza bildirme, ciro girme.
*   **Personel:** Vardiya takibi.

### 1.3. Tanımlamalar ve Kısaltmalar
*   **AVM:** Alışveriş Merkezi
*   **Kiracı (Tenant):** AVM içerisinde mağaza kiralayan tüzel kişilik.
*   **ORM:** Object Relational Mapping (Entity Framework)
*   **DevExpress:** Kullanılan UI bileşen kütüphanesi.

---

## 2. PROJE PLANI

### 2.1. Proje Zaman-İş Planı
*   **Hafta 1-2:** Gereksinim Analizi ve Veritabanı Tasarımı (ER Diyagramları).
*   **Hafta 3-4:** Altyapı Kurulumu (Entity Framework, Katmanlı Mimari).
*   **Hafta 5-6:** Yönetici Modülü Geliştirimi (Mağaza, Personel CRUD).
*   **Hafta 7-8:** Kiracı Modülü ve Talep Yönetim Sistemi.
*   **Hafta 9:** Raporlama ve Test Süreçleri.

### 2.2. Proje Ekip Yapısı
*   **Proje Yöneticisi & Analist:** (Öğrenci Adı)
*   **Yazılım Geliştirici:** (Öğrenci Adı)
*   **Veritabanı Yöneticisi:** (Öğrenci Adı)

### 2.3. Kullanılan Araçlar ve Ortamlar
*   **IDE:** Visual Studio 2019/2022
*   **Dil:** C# .NET Framework
*   **VTYS:** Microsoft SQL Server
*   **UI Framework:** DevExpress

---

## 3. SİSTEM ÇÖZÜMLEME

### 3.1. Mevcut Sistem İncelemesi
Mevcut durumda birçok AVM, kiracı iletişimini telefon/e-posta ile yürütmekte, finansal takibi Excel dosyalarında yapmakta ve teknik servis taleplerini kağıt formlarla yönetmektedir. Bu durum veri kaybına, gecikmelere ve raporlama zorluğuna yol açmaktadır.

### 3.2. Gereksenen Sistemin Mantıksal Modeli
*   **İşlevsel Model:** Sistem, "Talep Döngüsü" (Request Lifecycle) üzerine kuruludur. Bir mağaza talebi oluşturur (Input), yönetim görür ve işler (Process), sonuç mağazaya bildirilir (Output).
*   **Veri Modeli:** İlişkisel Veritabanı (RDBMS) modeli kullanılmıştır. Mağazalar, Kiracılar, Personeller ve Talepler birbiriyle Primary Key - Foreign Key ilişkisi içindedir.

---

## 4. SİSTEM TASARIMI

### 4.1. Sistem Mimarisi
Proje **N-Katmanlı (N-Layered) Mimari** kullanılarak tasarlanmıştır:
1.  **AVM.Core:** Varlıklar (Entities) ve arayüzler. (Bütün katmanların eriştiği ortak yapı).
2.  **AVM.DataAccess:** Veritabanı erişim kodları (Repository Pattern, EF Context).
3.  **AVM.Business:** İş mantığı, validasyonlar ve hesaplamalar.
4.  **AVM.UI:** Kullanıcı arayüzü (Formlar, Kontroller).

### 4.2. Veri Tasarımı (Veri Modeli)
**Temel Tablolar:**
*   `Stores` (PK: StoreId, Name, Floor, Size...)
*   `Users` (PK: UserId, Username, RoleId, StoreId...)
*   `Tenants` (PK: TenantId, StoreId, ContactInfo...)
*   `ServiceRequests` (PK: RequestId, StoreId, Description, Status...)
*   `LeaveRequests` (PK: LeaveId, EmployeeId, Status...)

### 4.3. Süreç Tasarımı (Modüller)
*   **Login Modülü:** Kullanıcı `RoleId` ve `StoreId` kontrolü ile dinamik yönlendirme ("Factory Pattern" benzeri yapı).
*   **Talep Yönetimi Modülü:** Durum makinesi (State Machine) mantığı ile `Pending` -> `Approved`/`Rejected` geçişleri.

---

## 5. SİSTEM GERÇEKLEŞTİRİMİ

### 5.1. Kodlama Stili
*   **Clean Code:** Metotlar tek bir işi yapacak şekilde parçalanmıştır (Single Responsibility).
*   **İsimlendirme:** `PascalCase` sınıf adları, `camelCase` değişken adları kullanılmıştır.
*   **Yorum Satırları:** Karmaşık LINQ sorgularında açıklayıcı yorumlar eklenmiştir.

### 5.2. McCable Karmaşıklık Analizi
`ServiceRequestManager.GetRequestsByStore` gibi metotlar düşük karmaşıklığa sahiptir (Cyclomatic Complexity < 5). Ancak `Login` işlemindeki `if-else` blokları karmaşıklığı artırdığı için ayrı bir `UserManager` sınıfına delege edilmiştir.

### 5.3. Olağan Dışı Durum Çözümleme
*   `try-catch` blokları ile veritabanı bağlantı hataları yakalanır.
*   Kullanıcı hatalarında (örn: Mağazasız kullanıcı girişi) kullanıcıya açıklayıcı `MessageBox` uyarıları (Image 1'deki gibi) gösterilir.

---

## 6. DOĞRULAMA VE GEÇERLEME (TEST)

### 6.1. Sınama Yöntemleri
*   **Beyaz Kutu Sınaması (White Box):** Kodun iç yapısı, döngüler ve koşullar geliştirici tarafından test edilmiştir.
*   **Senaryo Testleri:** "Mavi Mağaza Müdürü sisteme girer, izin talep eder, Admin sisteme girer ve talebi onaylar" senaryosu başarıyla koşturulmuştur (`seed_data.sql` verileri ile).

### 6.2. Test Sonuçları
*   Login işlemi: Başarılı.
*   Veri Ekleme/Güncelleme: Başarılı.
*   Yabancı Anahtar (FK) Kısıtlamaları: Veritabanı seviyesinde korunmaktadır.

---

## 7. BAKIM

### 7.1. Kurulum
Proje bir `Setup.exe` veya klasör kopyalama yöntemiyle kurulabilir.
Gereksinimler: .NET Framework 4.7.2+, SQL Server (LocalDB veya Express).

### 7.2. Gelecek Bakım Planı
*   Yapay Zeka Destekli Ciro Tahmini (Opsiyonel özellikler listesinden).
*   Mobil Uygulama Entegrasyonu (API katmanı eklenerek).

---

## 8. SONUÇ
AVM Yönetim Sistemi projesi, belirtilen gereksinimler doğrultusunda, modern yazılım mühendisliği prensipleri gözetilerek başarıyla tamamlanmıştır. Modüler yapısı sayesinde yeni özelliklere açıktır ve gerçek dünya senaryolarında (10 mağaza, 30+ personel simülasyonu ile) test edilmiştir. Proje, hem akademik öğrenim çıktılarını karşılamakta hem de ticari bir ürün potansiyeli taşımaktadır.
