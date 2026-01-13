# AVM Yönetim Sistemi - Veri Seti Yol Haritası (Data Seeding Roadmap)

Bu belge, "AVM Yönetim Sistemi" projesinin tamamen gerçekçi, yaşayan bir veri seti ile doldurulması için izlenecek adımları belirler.

## Amaç
Sistemin tüm fonksiyonlarını (Login, Raporlama, İzinler, Mesajlaşma) test etmek ve demolar için "dolu" bir veritabanı oluşturmak.

---

## 📅 Faz 1: Altyapı ve Kurumsal Kimlik (Foundation)

Bu aşamada AVM'nin fiziksel ve idari yapısı kurulacak.

### 1.1. Mağazalar (Stores)
Gerçek marka isimleri ve logoları kullanılacak.
*   **Hedef:** 10 Adet Mağaza
*   **Örnekler:** 
    *   *Moda:* Mavi, LC Waikiki, Zara, Boyner
    *   *Teknoloji:* Teknosa, MediaMarkt
    *   *Yeme-İçme:* Starbucks, Mado, Burger King
    *   *Hizmet:* Eczane, Terzi

### 1.2. Roller ve Yetkiler
*   **Admin:** AVM Yönetimi
*   **Personel:** AVM Personeli (Güvenlik, Temizlik)
*   **Mağaza (Tenant):** Mağaza Müdürü

---

## 👥 Faz 2: İnsan Kaynakları (Users & Employees)

Her mağaza ve birim için gerçek Türk isimlerine sahip kullanıcılar oluşturulacak.

### 2.1. Kullanıcılar (Users)
*   **Yönetici:** `admin` (Şifre: 123456)
*   **Mağaza Yöneticileri:** 
    *   `mavi_mudur` -> Ahmet Yılmaz (StoreId: 1)
    *   `zara_mudur` -> Ayşe Demir (StoreId: 2)
    *   `starbucks_mudur` -> Mehmet Öz (StoreId: 3)
*   **AVM Personeli:** 
    *   `guvenlik_sef` -> Hakan Çelik (Rol: Personel, StoreId: NULL)

### 2.2. Çalışanlar (Employees)
Her mağazanın altında çalışan tezgahtarlar ve satış danışmanları.
*   **Mavi:** 3 Satış Danışmanı
*   **Starbucks:** 2 Barista
*   **LCW:** 4 Reyon Görevlisi
*   **AVM:** 5 Güvenlik Görevlisi, 3 Temizlik Personeli

---

## 💼 Faz 3: Operasyonel Veriler (Operations)

Sistemi "yaşayan" bir hale getirmek için geçmişe dönük veriler eklenecek.

### 3.1. İzin Talepleri (Leave Requests)
*   **Senaryo:** Son 3 ay içinde yapılmış talepler.
*   **Durumlar:** %60 Onaylı, %30 Reddedilmiş (Red sebebi girilmiş), %10 Beklemede.
*   **Örnek:** "Yıllık İzin", "Hastalık İzni".

### 3.2. Teknik/Destek Talepleri (Service Requests)
*   **Senaryo:** Mağazaların AVM yönetiminden istekleri.
*   **Örnekler:**
    *   "Klima su akıtıyor" (Zara - Çözüldü)
    *   "Vitrin ışığı patladı" (Mavi - Beklemede)
    *   "Tuvalet tıkanıklığı" (Burger King - Çözüldü)

### 3.3. Vardiyalar (Shifts)
*   Güvenlik ve Temizlik personeli için haftalık vardiya çizelgesi.
*   Sabah (08:00-16:00), Akşam (16:00-24:00).

### 3.4. Görevler (Tasks)
*   "Zemin Kat Devriyesi", "Yangın Tüpü Kontrolü" gibi tamamlanmış ve açık görevler.

---

## 💰 Faz 4: Finansal Veriler (Financials)

### 4.1. Kira Sözleşmeleri (Contracts)
*   Her mağaza için aktif sözleşme.
*   Farklı başlangıç tarihleri ve kira bedelleri (TL/USD).

### 4.2. Ciro Bildirimleri (Turnovers)
*   Her mağaza için son 30 günün günlük ciroları. 
*   Hafta sonları daha yüksek, hafta içi daha düşük rakamlar.

### 4.3. Ödemeler (Payments)
*   Son 3 ayın kiralarının ödeme durumları (Tam, Eksik, Ödenmedi).

---

## 💬 Faz 5: İletişim (Communication)

### 5.1. Duyurular (Announcements)
*   "AVM Kapanış Saati Değişikliği", "Yangın Tatbikatı", "Bayram Tebriği".

### 5.2. Mesajlar (Messages)
*   Mağaza Müdürü <-> AVM Yönetimi arasındaki yazışmalar.

---

## 🛠️ Uygulama Planı

1.  **SQL Script Hazırlama:** Tüm bu verileri `INSERT INTO` komutlarıyla ekleyen tek bir SQL dosyası (`seed_data.sql`).
2.  **Temizleme:** `TRUNCATE TABLE` komutlarıyla mevcut test verilerinin temizlenmesi.
3.  **Çalıştırma:** Scriptin çalıştırılması ve UI kontrolü.
