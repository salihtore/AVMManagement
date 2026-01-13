AVM Yönetim Sistemi

AVM Yönetim Sistemi, alışveriş merkezlerinin operasyonel süreçlerini dijital ortamda merkezi ve modüler bir yapı ile yönetebilmek amacıyla geliştirilmiş bir masaüstü yazılım projesidir. Sistem; mağaza kiralama, personel yönetimi, teknik servis talepleri ve temel finansal takibi tek bir platformda birleştirerek yönetim süreçlerini hızlandırmayı ve veri bütünlüğünü sağlamayı hedefler.

Projenin Amacı

Bu projenin temel amacı, manuel yöntemlerle yürütülen AVM yönetim süreçlerini yazılım destekli hale getirerek:

Operasyonel verimliliği artırmak

Veri kaybı ve iletişim gecikmelerini azaltmak

Yönetim, kiracı ve personel arasındaki etkileşimi merkezi bir sistem üzerinden yürütmek

Akademik olarak katmanlı mimari, veritabanı tasarımı ve iş mantığı ayrımını uygulamaktır

Proje Kapsamı

Sistem üç ana kullanıcı grubuna sahiptir:

Yönetim

Mağaza ve kiracı yönetimi

Personel atama

Teknik servis taleplerini görüntüleme ve onaylama

Genel raporlama işlemleri

Kiracı (Mağaza Müdürü)

Kendi mağazasına ait personeli yönetme

Teknik servis talepleri oluşturma

Temel ciro ve bildirim işlemleri

Personel

Vardiya ve izin takibi

Sistem Mimarisi

Proje, N-Katmanlı Mimari (N-Layered Architecture) kullanılarak geliştirilmiştir.

AVM.Core
Varlık sınıfları (Entities) ve ortak arayüzler

AVM.DataAccess
Veritabanı erişim katmanı
Entity Framework, Repository ve Unit of Work desenleri

AVM.Business
İş mantığı, doğrulamalar ve kurallar

AVM.UI
Kullanıcı arayüzü (Windows Forms + DevExpress)

Bu yapı sayesinde katmanlar birbirinden bağımsızdır ve sistem genişletilmeye açıktır.

Kullanılan Teknolojiler

Programlama Dili: C#

Platform: .NET Framework

IDE: Visual Studio 2019 / 2022

Veritabanı: Microsoft SQL Server

ORM: Entity Framework

UI Framework: DevExpress

Veritabanı Yapısı

Sistem ilişkisel veritabanı modeli kullanmaktadır. Temel tablolar:

Stores

Users

Tenants

ServiceRequests

LeaveRequests

Tablolar arasında Primary Key ve Foreign Key ilişkileri tanımlanmış olup veri bütünlüğü veritabanı seviyesinde korunmaktadır.

Temel Modüller
Giriş (Login) Modülü

Kullanıcı rolüne göre yetkilendirme

Rol bazlı ekran yönlendirme

Talep Yönetim Modülü

Teknik servis ve izin talepleri

Durum bazlı akış (Beklemede, Onaylandı, Reddedildi)

Yönetim Modülü

Mağaza ve kiracı işlemleri

Personel yönetimi

Yazılım Mühendisliği Yaklaşımı

Temiz kod prensipleri uygulanmıştır

Sorumluluklar sınıflar arasında net şekilde ayrılmıştır

Karmaşık işlemler küçük ve okunabilir metotlara bölünmüştür

Döngüsel karmaşıklığı yüksek yapılar refactor edilmiştir

Test ve Doğrulama

Beyaz kutu testleri uygulanmıştır

Senaryo bazlı testler gerçekleştirilmiştir

Veritabanı kısıtlamaları ile hatalı veri girişleri engellenmiştir

Test edilen temel senaryolar:

Kullanıcı girişi

Veri ekleme ve güncelleme

Talep oluşturma ve onay süreçleri

Kurulum

Projeyi bilgisayarınıza klonlayın veya indirin

SQL Server üzerinde veritabanını oluşturun

Gerekli bağlantı ayarlarını yapın

Projeyi Visual Studio üzerinden çalıştırın

Gereksinimler:

.NET Framework 4.7.2 veya üzeri

SQL Server (LocalDB veya Express)

Gelecek Geliştirmeler

Ciro tahmini için analiz modülü

API katmanı eklenerek mobil uygulama entegrasyonu

Gelişmiş raporlama ve grafik ekranları

Sonuç

AVM Yönetim Sistemi, yazılım mühendisliği prensiplerine uygun olarak geliştirilmiş, modüler ve genişletilebilir bir masaüstü uygulamasıdır. Proje; akademik gereksinimleri karşılamakla birlikte, gerçek dünya senaryolarında uygulanabilir bir yönetim sistemi altyapısı sunmaktadır.
