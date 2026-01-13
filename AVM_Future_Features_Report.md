# Gelecek Özellikler Raporu: Mağaza ve Personel Panelleri

## 1. Yönetici Paneli Analizi (Mevcut Durum)
Mevcut Yönetici paneli şu modülleri kapsar:
- **Mağazalar & Kiracılar:** AVM bünyesindeki işletmelerin ve sözleşmelerin takibi.
- **Kira Ödemeleri:** Gelir takibi.
- **Giderler:** AVM'nin işletme giderleri.
- **Personeller:** AVM personel yönetimi.
- **Duyurular:** İletişim.

Bu yapı merkezi bir yönetim sunmaktadır. Aşağıdaki öneriler, bu merkezi yapıyı besleyecek ve operasyonel yükü dağıtacak "Uç Birim" (Mağaza ve Personel) özellikleridir.

## 2. Mağaza Paneli (Store Login) Önerileri
Mağaza yetkililerinin sisteme girdiğinde göreceği özellikler, Yönetici paneliyle entegre olmalı ve veri akışını otomatize etmelidir.

### A. Ciro Girişi (Kritik)
*   **Mantık:** Kira sözleşmeleri genellikle "Sabit Kira + Ciro Payı" şeklindedir. Yönetici panelinin bunu hesaplayabilmesi için mağazaların günlük/aylık cirolarını girmesi gerekir.
*   **Özellik:** Basit bir form ile Tarih ve Tutar seçerek ciro bildirimi yapma.
*   **Admin Bağlantısı:** 'Kira Ödemeleri' modülüne otomatik veri akar.

### B. Teknik Servis / Talep Bildirimi
*   **Mantık:** Mağazada klima bozulabilir, su akabilir veya temizlik gerekebilir. Telefon trafiği yerine sistemden talep açılmalı.
*   **Özellik:** "Talep Oluştur" butonu (Arıza Tipi: Elektrik/Mekanik/Temizlik, Fotoğraf Yükleme, Açıklama).
*   **Admin Bağlantısı:** Yönetici panelinde yeni bir "Teknik Destek" veya "Talepler" modülü gerektirir.

### C. Personel Bildirimi
*   **Mantık:** AVM güvenliği için mağaza çalışanlarının kimlik bilgileri AVM yönetiminde olmalıdır.
*   **Özellik:** Kendi mağaza personelini ekleme/çıkarma yetkisi (Sadece bildirim amaçlı).
*   **Admin Bağlantısı:** 'Kiracılar' detayında mağaza çalışanlarını görme.

### D. Duyurular ve Borç Durumu
*   **Mantık:** Yönetimden gelen genelge ve uyarıları görme.
*   **Özellik:** Admin'in yayınladığı duyuruları okuma ("Okudum" onayı). Ayrıca güncel kira borç bakiyesini görüntüleme.

---

## 3. Personel Paneli (Staff Login) Önerileri
AVM'nin kendi personelleri (Güvenlik, Temizlik, Teknik) için mobil uyumlu olması tercih edilecek özelliklerdir.

### A. Vardiya Takvimi
*   **Mantık:** "Bugün hangi kapıda nöbetçiyim?" veya "Hangi katta temizlikteyim?" sorusunun cevabı.
*   **Özellik:** Admin tarafından atanan haftalık/aylık çalışma çizelgesini görüntüleme.

### B. Görev Listesi (Task Management)
*   **Mantık:** Admin'in "Kat 2 Tuvalet kontrol edilecek" gibi anlık görevler ataması.
*   **Özellik:** "Yapılacaklar" listesi ve görevi tamamlayınca "Tamamla" butonu (Tamamlanma saati loglanır).

### C. İzin Talepleri
*   **Mantık:** Kağıt formlar yerine dijital izin süreci.
*   **Özellik:** İzin Tipi (Yıllık/Mazeret), Tarih Aralığı seçip onaya gönderme.
*   **Admin Bağlantısı:** 'Personeller' modülüne onay mekanizması eklenmeli.

### D. Bordro Görüntüleme
*   **Mantık:** Maaş pusulalarına dijital erişim.
*   **Özellik:** Geçmiş aylara ait maaş detaylarını PDF olarak görüntüleme.

## 4. Özet ve Öncelik Sıralaması
Geliştirme sürecinde öncelik sırası şöyle olmalıdır:

1.  **Mağaza: Ciro Bildirimi** (Gelir hesaplaması için kritik)
2.  **Mağaza: Borç/Ödeme Takibi** (Finansal şeffaflık)
3.  **Personel: Vardiya/Program** (Operasyonel düzen)
4.  **Mağaza: Teknik Talepler** (Müşteri memnuniyeti ve tesis yönetimi)

Bu özellikler eklendiğinde sistem sadece bir "Kayıt Defteri" olmaktan çıkıp, yaşayan bir "AVM Ekosistemi"ne dönüşecektir.
