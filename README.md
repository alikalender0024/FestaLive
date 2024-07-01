FestaLive

FestaLive, Admin ve Kullanıcı Panelli bir festival yönetim sistemidir. Bu proje, Acunmedya Akademi'nin düzenlediği bootcamp eğitimi kapsamında geliştirilmiştir.

Proje Açıklaması

FestaLive, festivallerin yönetimini kolaylaştırmak amacıyla geliştirilmiş bir web uygulamasıdır. Admin paneli üzerinden festival bilgilerini yönetebilir, kullanıcılar festival etkinliklerine kaydolabilir ve etkinlik bilgilerini görüntüleyebilir.

Kullanılan Teknolojiler

ASP.NET MVC
Entity Framework (Code First)
JWT (JSON Web Token) ile kimlik doğrulama
Autofac ile bağımlılık enjeksiyonu
Log4Net ile günlükleme
FluentValidation ile doğrulama işlemleri
Redis ve Microsoft Cache ile önbellekleme
AOP (Aspect-Oriented Programming) ile performans ve işlem yönetimi
Özellikler
Admin Paneli: Festival bilgilerini düzenleme ve yönetme
Kullanıcı Paneli: Kullanıcıların etkinliklere kaydolması ve etkinlik bilgilerini görüntülemesi
CRUD Operasyonları: Veritabanı işlemleri için temel CRUD operasyonları desteklenmektedir.
Önbellekleme: Redis ve Microsoft Cache ile performansı artırmak için önbellekleme yapılmaktadır.
Kurulum
Proje yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.Gereksinimler
.NET Framework 4.7.2 veya üzeri
SQL Server

2.Projeyi İndirme
git clone https://github.com/walikalender/FestaLive.git


3.Veritabanı Ayarları
appsettings.json dosyasında SQL Server bağlantı dizesini ayarlayın.

4.Uygulamayı Çalıştırma
Visual Studio kullanarak projeyi açın.
Projeyi derleyin ve çalıştırın.

5.Admin Paneli Erişimi
http://localhost:port/Admin adresine giderek admin paneline erişebilirsiniz. Varsayılan admin kimlik bilgileri: admin/password.

Katkıda Bulunma
Bu proje açık kaynaklıdır ve katkıda bulunmaktan memnuniyet duyarız. Kodu çatallayın (fork) ve geliştirme önerilerinizi yapın.

Proje çatallayın (fork).
Yeni bir dal (branch) oluşturun (git checkout -b feature/yeniozellik).
Değişikliklerinizi uygulayın (git add .), (git commit -m 'Yeni özellik: Yeni özellik eklendi').
Dalınıza itin (push) (git push origin feature/yeniozellik).
Bir çekme isteği (pull request) oluşturun.
Lisans
Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için LICENSE dosyasına bakabilirsiniz.
