The more advanced version of this project is in this repository : https://github.com/Agshinhummatov/E-CommerceAPI-ASP.NET-Core-OnionArchitectureProject


# ECommerce Project

This project aims to [briefly describe the project purpose].

## Technologies Used

- ASP.NET Core
- MediatR CQRS
- Entity Framework Core 
- Onion Architecture
- Swagger
- PostgreSQL
- Docker (optional, if used)
- JWT Authentication (optional, if used)

## Project Overview

This project [provide a more detailed description of the project's goals and scope].

## Folder Structure

The project follows the principles of Onion Architecture, with the following folder structure:

- **Application**: Application services and CQRS commands/handlers.
- **Domain**: Domain models and business logic.
- **Infrastructure**: Database connections, external services, and data persistence layer.
- **Presentation**: API controllers and Swagger configuration.

## Persistence Layer

The persistence layer includes database interactions and concrete service implementations:

- **ProductRepository**: Handles database operations related to products.
- **OrderRepository**: Manages database operations for orders.
- **UserRepository**: Implements database operations for user-related data.

## Validation and Filters

### Validation Filters

Validation filters are implemented using FluentValidation for robust input validation:

- **CreateProductValidator**: Validates `CreateProductCommandRequest` before processing, enforcing rules for product name, description, stock, and price.

### Action Filters

Action filters, such as `ValidationFilter`, intercept requests before execution to ensure data validity:

- **ValidationFilter**: Checks `ModelState.IsValid` before action execution. If invalid, it returns a `BadRequestObjectResult` with detailed validation errors.

## Getting Started

To get started with the project locally or on a server, follow these steps:
1. [Instructions on setting up prerequisites, dependencies, and environment variables].
2. [How to run the project locally or deploy it on a server].
3. [Additional configuration steps, if any].

## API Documentation

Explore the project's API endpoints using Swagger UI at [URL]. Here you can test and interact with various endpoints.

## Contributing

Contributions are welcome! Please follow [guidelines or instructions for contributing], and submit pull requests.



API Endpoints
Products
GET /api/products: Get all products.
GET /api/products/{id}: Get product by id.
POST /api/products: Create a new product.
PUT /api/products/{id}: Update a product.
DELETE /api/products/{id}: Delete a product.
Users
POST /api/users/register: Register a new user.
POST /api/users/login: Login and generate JWT token.
PUT /api/users/update-password: Update user password.
Baskets
GET /api/baskets: Get basket items.
POST /api/baskets/add-item: Add item to basket.
PUT /api/baskets/update-quantity: Update item quantity in basket.
DELETE /api/baskets/remove-item/{basketItemId}: Remove item from basket.
Orders
GET /api/orders/{id}: Get order by id.
GET /api/orders: Get all orders.
POST /api/orders: Create a new order.
GET /api/orders/complete-order/{id}: Complete an order.



Azerbaijan : 

Bu layihənin daha təkmil versiyası bu depodadır: https://github.com/Agshinhummatov/E-CommerceAPI-ASP.NET-Core-OnionArchitectureProject


# Elektron Ticarət Layihəsi

Bu layihə [layihənin məqsədini qısaca təsvir etmək] məqsədi daşıyır.

## İstifadə olunan Texnologiyalar

- ASP.NET Core
- MediatR CQRS
- Entity Framework Core
- Soğan Memarlığı
- Swagger
- PostgreSQL
- Docker (istəyə görə, istifadə olunarsa)
- JWT Authentication (istəyə görə, əgər istifadə olunarsa)

## Layihəyə Baxış

Bu layihə [layihənin məqsədləri və əhatə dairəsinin daha ətraflı təsvirini təqdim edir].

## Qovluq Strukturu

Layihə aşağıdakı qovluq strukturu ilə Onion Architecture prinsiplərinə əməl edir:

- **Tətbiq**: Tətbiq xidmətləri və CQRS əmrləri/işləyiciləri.
- **Domen**: Domen modelləri və biznes məntiqi.
- **İnfrastruktur**: verilənlər bazası əlaqələri, xarici xidmətlər və məlumatların davamlılığı səviyyəsi.
- **Təqdimat**: API nəzarətçiləri və Swagger konfiqurasiyası.

## Davamlılıq Layeri

Davamlılıq qatına verilənlər bazası ilə qarşılıqlı əlaqə və konkret xidmət tətbiqetmələri daxildir:

- **ProductRepository**: Məhsullarla bağlı verilənlər bazası əməliyyatlarını idarə edir.
- **OrderRepository**: Sifarişlər üçün verilənlər bazası əməliyyatlarını idarə edir.
- **UserRepository**: İstifadəçi ilə əlaqəli məlumatlar üçün verilənlər bazası əməliyyatlarını həyata keçirir.

## Doğrulama və Filtrlər

### Doğrulama Filtrləri

Təsdiqləmə filtrləri möhkəm giriş yoxlaması üçün FluentValidation istifadə edərək həyata keçirilir:

- **CreateProductValidator**: Məhsulun adı, təsviri, ehtiyatı və qiyməti üçün qaydaları tətbiq edərək emal etməzdən əvvəl "CreateProductCommandRequest"i təsdiqləyir.

### Fəaliyyət Filtrləri

`ValidationFilter` kimi fəaliyyət filtrləri verilənlərin etibarlılığını təmin etmək üçün icradan əvvəl sorğuları kəsir:

- **ValidationFilter**: Fəaliyyətin icrasından əvvəl `ModelState.IsValid` yoxlayır. Yanlışdırsa, o, təfərrüatlı doğrulama xətaları ilə `BadRequestObjectResult` qaytarır.

## Başlamaq

Layihəyə yerli və ya serverdə başlamaq üçün bu addımları yerinə yetirin:
1. [İlkin şərtlərin, asılılıqların və mühit dəyişənlərinin qurulması üzrə təlimatlar].
2. [Layihəni yerli olaraq necə idarə etmək və ya serverdə yerləşdirmək].
3. [Əgər varsa, əlavə konfiqurasiya addımları].

## API Sənədləri

[URL] ünvanında Swagger UI istifadə edərək layihənin API son nöqtələrini araşdırın. Burada müxtəlif son nöqtələri sınaqdan keçirə və onlarla əlaqə saxlaya bilərsiniz.

## Töhfə

Töhfələr xoş gəlmisiniz! Lütfən, [töhfə vermək üçün təlimatlara və ya təlimatlara] əməl edin və cəlbetmə sorğularını göndərin.


Turkey :

Bu projenin daha gelişmiş versiyonu şu depodadır: https://github.com/Agshinhummatov/E-CommerceAPI-ASP.NET-Core-OnionArchitectureProject


# E-Ticaret Projesi

Bu proje [proje amacını kısaca açıklamayı] amaçlamaktadır.

## Kullanılan Teknolojiler

- ASP.NET Çekirdeği
- MediatR CQRS
- Varlık Çerçevesi Çekirdeği
- Soğan Mimarisi
- Havalı
-PostgreSQL
- Docker (kullanılıyorsa isteğe bağlı)
- JWT Kimlik Doğrulaması (kullanılıyorsa isteğe bağlı)

## Projeye Genel Bakış

Bu proje [projenin hedeflerinin ve kapsamının daha ayrıntılı bir tanımını sağlayın].

## Klasör Yapısı

Proje, aşağıdaki klasör yapısıyla Onion Mimarisinin ilkelerini takip ediyor:

- **Uygulama**: Uygulama hizmetleri ve CQRS komutları/işleyicileri.
- **Etki alanı**: Etki alanı modelleri ve iş mantığı.
- **Altyapı**: Veritabanı bağlantıları, harici hizmetler ve veri kalıcılığı katmanı.
- **Sunum**: API denetleyicileri ve Swagger yapılandırması.

## Kalıcılık Katmanı

Kalıcılık katmanı, veritabanı etkileşimlerini ve somut hizmet uygulamalarını içerir:

- **ProductRepository**: Ürünlerle ilgili veritabanı işlemlerini gerçekleştirir.
- **OrderRepository**: Siparişlere ilişkin veritabanı işlemlerini yönetir.
- **UserRepository**: Kullanıcıyla ilgili veriler için veritabanı işlemlerini uygular.

## Doğrulama ve Filtreler

### Doğrulama Filtreleri

Doğrulama filtreleri, sağlam giriş doğrulaması için FluentValidation kullanılarak uygulanır:

- **CreateProductValidator**: "CreateProductCommandRequest"i işlemeden önce doğrular ve ürün adı, açıklama, stok ve fiyatla ilgili kuralları uygular.

### Eylem Filtreleri

'ValidationFilter' gibi eylem filtreleri, veri geçerliliğini sağlamak için istekleri yürütmeden önce durdurur:

- **ValidationFilter**: Eylem yürütülmeden önce `ModelState.IsValid`i kontrol eder. Geçersizse, ayrıntılı doğrulama hatalarını içeren bir "BadRequestObjectResult" döndürür.

## Başlarken

Projeye yerel olarak veya bir sunucuda başlamak için şu adımları izleyin:
1. [Önkoşulları, bağımlılıkları ve ortam değişkenlerini ayarlama talimatları].
2. [Proje yerel olarak nasıl çalıştırılır veya bir sunucuya dağıtılır].
3. [Varsa ek yapılandırma adımları].

## API Belgeleri

[URL] adresindeki Swagger kullanıcı arayüzünü kullanarak projenin API uç noktalarını keşfedin. Burada çeşitli uç noktaları test edebilir ve bunlarla etkileşimde bulunabilirsiniz.

## Katkı

Katkılarınızı bekliyoruz! Lütfen [katkıda bulunma yönergelerini veya talimatlarını] takip edin ve çekme istekleri gönderin.




