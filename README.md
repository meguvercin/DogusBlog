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

```
DogusBlog/
├── Controllers/
│   ├── PostsController.cs
│   └── UsersController.cs
│
├── Data/
│   ├── Abstract/
│   │   ├── ICommentRepository.cs
│   │   ├── IPostRepository.cs
│   │   ├── ITagRepository.cs
│   │   └── IUserRepository.cs
│   └── Concrete/
│       └── EfCore/
│           ├── BlogContext.cs
│           ├── EfCommentRepository.cs
│           ├── EfPostRepository.cs
│           ├── EfTagRepository.cs
│           ├── EfUserRepository.cs
│           └── SeedData.cs
│
├── Entity/
│   ├── Comment.cs
│   ├── Post.cs
│   ├── Tag.cs
│   └── User.cs
│
├── Models/
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── PostCreateViewModel.cs
│   └── PostViewModel.cs
│
├── ViewComponents/
│   ├── TagsMenuViewComponent.cs
│   └── NewPostsViewComponent.cs
│
├── Views/
│   ├── Posts/
│   ├── Shared/
│   └── Users/
│
├── wwwroot/
│   └── img/
│       ├── profile-picture.png
│       ├── yazı1.jpg
│       └── yazı2.jpg
```
## 🛠️ Kurulum Talimatları

1. Projeyi Visual Studio 2022 veya üzeri ile açın.
2. Paketleri yükleyin:
   ```
   dotnet restore
   ```
3. Veritabanını oluşturmak için:
   ```
   dotnet ef database update
   ```
4. Uygulamayı başlatın:
   ```
   dotnet run
   ```

## 🌱 Seed Data

- 2 kullanıcı otomatik olarak eklenir:
  - Admin:
    - **Kullanıcı Adı:** meguvercin
    - **Email:** info@meguvercin.com
    - **Şifre:** 123456
  - Kullanıcı:
    - **Kullanıcı Adı:** emin
    - **Email:** info@emin.com
    - **Şifre:** 123456

- 5 etiket:
  - web programlama, backend, frontend, game, fullstack

- 3 örnek post (başlangıç için otomatik olarak eklenir)


## 👤 Geliştirici

Mehmet Emin Güvercin  
Doğuş Üniversitesi, Bilgisayar Mühendisliği
