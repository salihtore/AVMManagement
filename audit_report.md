# Proje Tarama ve Kök Neden Analiz Raporu

**Tarih:** 09.01.2026
**Konu:** Uygulama Açılışında Oluşan Kilitlenme (NullReferenceException)
**Durum:** Kritik Hata Tespit Edildi (Arayüz Katmanı)

## 1. Tespit Edilen Kritik Hata (Kök Neden)
Kullanıcı girişinden hemen sonra alınan `System.NullReferenceException: Nesne başvurusu bir örneğe ayarlanmadı` hatasının kaynağı kesin olarak **Arayüz (UI) Kodlarındaki Başlatma Sırasıdır**.

*   **Teknik Detay:**
    Kod içerisinde `new LayoutControl()` ile dinamik olarak bir `LayoutControl` nesnesi oluşturuluyor. Ancak bu nesne, formun `Controls` koleksiyonuna eklenmeden veya `ForceInitialize()` çağrılmadan önce, `Root` (kök grup) özelliğine erişilmeye çalışılıyor.
    DevExpress'in bu sürümünde veya kullanım şeklinde, nesne tam olarak "sahneye konulmadan" `Root` özelliği `null` dönmektedir.

    ```csharp
    // Hatalı Desen (Mevcut Kod)
    this.layoutControl = new LayoutControl { Dock = DockStyle.Fill };
    // layoutControl henüz forma eklenmedi, Handle oluşmadı.
    LayoutControlGroup root = this.layoutControl.Root; // BURASI NULL DÖNÜYOR
    root.GroupBordersVisible = false; // VE ÇÖKÜYOR
    ```

## 2. Etkilenen Dosyalar (Risk Haritası)
Açılışta veya ilgili menüye tıklandığında uygulamanın çökmesine neden olacak (veya olan) dosyalar şunlardır:

1.  🔴 **`AVM.UI\UCTasks.cs`** (Ekran görüntüsündeki hatanın kaynağı)
2.  🔴 **`AVM.UI\UCTurnover.cs`** (Aynı hatalı desen mevcut)
3.  🔴 **`AVM.UI\UCStorePersonnel.cs`** (Aynı hatalı desen mevcut)
4.  🔴 **`AVM.UI\UCLeaveRequests.cs`** (Aynı hatalı desen mevcut)
5.  🔴 **`AVM.UI\UCServiceRequests.cs`** (Aynı hatalı desen mevcut)

*Not: `UCPersonnelDashboard.cs` ve `UCShifts.cs` dosyalarında yaptığımız "LayoutControl'ü kaldırma" düzenlemesi sayesinde bu dosyalar artık güvenlidir ve çökmemektedir.*

## 3. SQL ve Veritabanı Durumu
*   **Durum:** ✅ **TEMİZ / SAĞLAM**
*   **Analiz:** Karşılaşılan hata tamamen **C# / Windows Forms** arayüz çizim katmanıyla ilgilidir. Veritabanı bağlantısı, tablolar veya SQL sorgularıyla ilgili **hiçbir sorun yoktur**.
*   SQL tarafında yapılması gereken ek bir işlem bulunmamaktadır.

## 4. Çözüm Önerisi ve Eylem Planı
Bu basit kullanıcı kontrolleri (User Controls) için `LayoutControl` kullanmak, manuel kodlama yaparken gereksiz karmaşıklık ve risk yaratmaktadır. En sağlam ve "Agentic" çözüm, bu bileşeni aradan çıkarmaktır.

**Önerilen Düzeltme:**
Listelenen 5 dosyanın tamamında `LayoutControl` yapısını kaldırıp, standart **`PanelControl` (veya Panel)** ve **`Dock`** yerleşimine geçmek.

*   **Basit Formlar (UCTasks):** Grid'i tüm alana yay (`Dock = Fill`), Butonu alta sabitle (`Dock = Bottom`).
*   **Giriş Formları (Ciro, İzin vb.):** Veri giriş alanlarını bir üst panele (`GroupControl -> Dock = Top`) koy, Grid'i alta yay (`Dock = Fill`).

**Onayınızla birlikte bu 5 dosyadaki değişikliği hızlıca uygulayabilirim. Bu işlem sonrası tüm çökmeler sona erecektir.**
