# AVM Yönetim Sistemi - Mantıksal Durum ve Eksiklik Raporu

Bu rapor, mevcut kod tabanının taranması sonucunda oluşturulmuş, "Varolan" ve "Mantıken Olması Gereken" durumları karşılaştıran analizdir.

## 1. Giriş ve Yetkilendirme (Authentication)

### Durum
- **Varolan:** `LoginForm` kullanıcıyı rolüne göre (Yönetici, Personel, Mağaza) yönlendiriyor. Ancak Mağaza (Tenant) girişinde sürekli **sabit bir StoreID (1)** kullanılıyor.
- **Olması Gereken:** Giriş yapan kullanıcının (`User`) hangi Mağazaya (`Store`) veya Kiracıya (`Tenant`) bağlı olduğu veritabanından çekilmeli ve `TenantForm` bu ID ile açılmalıdır. Aksi takdirde her giren kullanıcı 1 numaralı mağazayı yönetir.

### Çözüm Önerisi
- `User` tablosuna veya ilişkili bir tabloya `StoreId` bilgisi eklenmeli/kontrol edilmeli.
- `LoginForm` içinde bu ID alınıp `new TenantForm(userStoreId)` şeklinde parametre olarak geçilmeli.

---

## 2. Mağaza Talepleri (Service Requests)

### Durum
- **Varolan:** Mağazalar (`TenantForm`), `UCServiceRequests` üzerinden Arıza/Destek talebi oluşturabiliyor. Veritabanına kaydediliyor.
- **Olması Gereken:** Bu taleplerin bir muhatabı olmalı. Yönetici Paneli (`AdminForm`) üzerinde, mağazalardan gelen taleplerin listelendiği ve durumunun (Beklemede -> Çözüldü) güncellendiği bir ekran olmalı.

### Çözüm Önerisi
- Admin paneline **"Gelen Talepler"** modülü eklenmeli.

---

## 3. Personel İzin Yönetimi

### Durum
- **Varolan:** 
    - Mağaza Personeli izin isteyebiliyor, Mağaza Müdürü onaylayabiliyor (Bunu yeni yaptık ✅).
    - AVM Personeli (`PersonnelForm`) izin istiyor, ancak bu talebi onaylayacak bir ekran henüz yok.
- **Olması Gereken:** AVM Yönetimi (Admin), kendi bünyesindeki (Güvenlik, Temizlik vb.) personelin izin taleplerini görmeli ve onaylamalıdır.

### Çözüm Önerisi
- Admin paneline **"Personel İzinleri"** (AVM personeli için) modülü eklenmeli.

---

## 4. Finans ve Kira Sistemi

### Durum
- **Varolan:** `RentManager` içinde `GenerateCurrentMonthRents` (Bu ayın kiralarını oluştur) metodu var. Ödeme alma ekranı (`PaymentForm`) var.
- **Olması Gereken:** Kiraların ay başında oluşması için bir tetikleyici lazım. Ya sistem otomatik yapmalı (Windows Service/Job) ya da Admin panelinde **"Yeni Ay Kiralarını Oluştur"** butonu olmalı. Şu an bu metot çağrılmıyor olabilir.

### Çözüm Önerisi
- Admin Paneli -> Kira Yönetimi kısmına "Dönem Kiralarını Oluştur" butonu eklenmeli.

---

## 5. Ciro Takibi (Turnovers)

### Durum
- **Varolan:** Mağazalar ciro girebiliyor. Veritabanına kaydediliyor.
- **Olması Gereken:** Eğer kira sözleşmeleri "Ciro Bazlı Kira" içeriyorsa, girilen bu cirolar ay sonundaki kira tutarını etkilemeli. Şu an sadece bilgi amaçlı duruyor gibi.

### Çözüm Önerisi
- Kira hesaplama mantığına Ciro entegrasyonu (Opsiyonel, ileri seviye özellik).
- Admin panelinde mağazaların cirolarını raporlayan bir grafik/ekran (Mevcut olabilir, kontrol edilmeli).

---

## Özet Tablo

| Modül | Varolan | Olması Gereken | Aciliyet |
| :--- | :--- | :--- | :--- |
| **Login** | Sabit StoreID | Dinamik StoreID Transferi | 🔴 Kritik |
| **Destek** | Sadece Talep Oluşturma | Admin Çözüm Ekranı | 🟠 Yüksek |
| **İzin (AVM)** | Talep Var, Onay Yok | Admin Onay Ekranı | 🟠 Yüksek |
| **Kira** | Metot Var, Tetikleyici Yok | "Kiraları Oluştur" Butonu | 🟡 Orta |
| **SQL** | Tablolar Eşitlendi | Tamamlandı | 🟢 Tamam |

Bu rapor doğrultusunda, öncelikle **Login** yapısını düzeltmenizi, ardından **Admin Talep Yönetimi** ekranını eklemenizi öneririm.
