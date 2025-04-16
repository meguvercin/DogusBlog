# 📝 Dogus Blog

**Dogus Blog**, ASP.NET Core MVC ile geliştirilmiş, kullanıcıların blog yazıları paylaşabildiği, yorum yapabildiği, etiketleme ve görsel yükleme özellikleri bulunan modern bir blog platformudur. Bu proje, yazılım geliştirici olarak bir bootcamp işe alım süreci kapsamında teknik becerileri göstermek amacıyla geliştirilmiştir.

---

## 🚀 Özellikler

- ✅ **Kullanıcı yönetimi:** Kayıt olma, giriş yapma, çıkış yapma, profil düzenleme
- 📝 **Blog sistemi:** Yazı oluşturma, düzenleme, silme (kapak görseli ile birlikte)
- 🏷️ **Etiketleme:** Yazılara tag ekleme ve tag bazlı filtreleme
- 📷 **Profil resmi & kapak görseli yükleme**
- 💬 **Yorum sistemi:** Yazılara yorum yapma, kendi yorumunu silebilme
- 🔐 **Yetki sistemi:** Admin ve kullanıcı rolleri
- 🧠 **Zengin içerik editörü:** TinyMCE entegrasyonu
- 🧪 **Seed Data:** Örnek kullanıcı, yazı, yorum ve tag verileri
- 📱 **Responsive tasarım:** Bootstrap 5 ile mobil uyumlu arayüz

---

## 🧑‍💻 Yetkiler

| Özellik | Admin | Kullanıcı |
|--------|--------|-----------|
| Tüm postları görme | ✅ | ✅ |
| Tüm postları düzenleme | ✅ | ❌ |
| Kendi postlarını düzenleme | ✅ | ✅ |
| Tüm yorumları silme | ✅ | ❌ |
| Kendi yorumunu silme | ✅ | ✅ |
| Tüm kullanıcıları görme | ❌ | ❌ |
| Profilini güncelleme | ✅ | ✅ |

---

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core MVC (.NET 7.0)
- Entity Framework Core + Code First
- MS SQL Server
- Razor View Engine
- TinyMCE (CDN üzerinden)
- Bootstrap 5
- Cookie Authentication
- Repository Pattern

---
## 📁 Proje Klasör Yapısı
DogusBlog/
│
├── Controllers/
│   ├── PostsController.cs
│   └── UsersController.cs
│
├── Data/
│   ├── Abstract/
│   └── Concrete/
│       └── EfCore/
│   └── SeedData.cs
│
├── Entity/
│   ├── User.cs
│   ├── Post.cs
│   ├── Comment.cs
│   └── Tag.cs
│
├── Models/
│   ├── RegisterViewModel.cs
│   ├── LoginViewModel.cs
│   ├── PostCreateViewModel.cs
│   └── PostViewModel.cs
│
├── Views/
│   ├── Posts/
│   ├── Users/
│   └── Shared/
│
├── ViewComponents/
│   └── TagsMenuViewComponent.cs
│   └── NewPostsViewComponent.cs
│
├── wwwroot/
│   ├── img/
│       ├── profile-picture.png
│       ├── yazı1.jpg
│       └── yazı2.jpg



## 👤 Geliştirici

Mehmet Emin Güvercin  
Doğuş Üniversitesi, Bilgisayar Mühendisliği
