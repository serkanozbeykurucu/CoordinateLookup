# CoordinateLookup API - Precision Geodata for Turkish Territories

[![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) [![Language](https://img.shields.io/badge/Language-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/) [![Database](https://img.shields.io/badge/Database-PostgreSQL-blue)](https://www.postgresql.org/) [![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

**🇬🇧 (English)**

***Harness the Power of Precise Turkish Geodata in Your .NET Applications!***

Introducing CoordinateLookup – a powerful, free, and open-source API designed specifically for developers who need accurate and detailed geographical insight into Turkey. Effortlessly transform raw coordinates (latitude & longitude) into meaningful administrative data, including provinces, districts, towns, and neighborhoods.

**Go beyond basic lookups:** calculate distances between locations and integrate advanced geospatial intelligence into your applications with ease and efficiency.

**🇹🇷 (Türkçe)**

***.NET Uygulamalarınızda Türkiye’nin Hassas Coğrafi Verilerini Güce Dönüştürün!***

Karşınızda CoordinateLookup – Türkiye’ye özel, hassas coğrafi verilerle çalışan geliştiriciler için özel olarak tasarlanmış güçlü, ücretsiz ve açık kaynaklı bir API. Ham koordinatları (enlem & boylam), iller, ilçeler, beldeler ve mahalleler gibi detaylı idari bilgilere zahmetsizce dönüştürün.

**Sadece konum sorgulamakla kalmayın:** Bölgeler arası mesafeleri hesaplayın ve gelişmiş konum zekasını projelerinize kolayca entegre edin.

---

## Table of Contents

- [Motivation](#motivation-motivasyon)
- [Features](#features-özellikler)
- [Technologies Used](#technologies-used-kullanılan-teknolojiler)
- [Getting Started](#getting-started-başlarken)
  - [Prerequisites](#prerequisites-önkoşullar)
  - [Installation & Setup](#installation--setup-kurulum)
  - [Running the API](#running-the-api-apiyi-çalıştırma)
- [API Endpoints](#api-endpoints-api-uç-noktaları)
  - [1. Get Geographical Location By Latitude And Longitude](#1-get-geographical-location-by-latitude-and-longitude)
  - [2. Get All Provinces](#2-get-all-provinces)
  - [3. Get Province By Id](#3-get-province-by-id)
  - [4. Get Province With Districts](#4-get-province-with-districts)
  - [5. Get Districts By Province Id](#5-get-districts-by-province-id)
  - [6. Get District With Towns](#6-get-district-with-towns)
  - [7. Get Towns By District Id](#7-get-towns-by-district-id)
  - [8. Get Town With Neighbourhoods](#8-get-town-with-neighbourhoods)
  - [9. Get Neighbourhoods By Town Id](#9-get-neighbourhoods-by-town-id)
  - [10. Get Distance Between Provinces (by ID)](#10-get-distance-between-provinces-by-id)
  - [11. Get Distance Between Districts (by ID)](#11-get-distance-between-districts-by-id)
  - [12. Get Distance Between Provinces (by Name)](#12-get-distance-between-provinces-by-name)
  - [13. Get Distance Between Districts (by Name)](#13-get-distance-between-districts-by-name)
- [References](#references-referanslar)
- [Contributing](#contributing-katkıda-bulunma)
- [License](#license-lisans)

---

## Motivation (Motivasyon)

**🇬🇧 (English)**

**Why did we build CoordinateLookup?**  
Because we needed it — and it didn’t exist.

Trying to map geographic coordinates to Turkish administrative data in .NET was either **too expensive**, **too incomplete**, or **too painful**. Commercial solutions charged high fees. Open datasets were messy, outdated, or difficult to use. Nothing just worked out of the box.

So we built the tool we wished we had — and made it free for everyone.
CoordinateLookup was born out of a simple belief: **Essential location tools should be accessible to all developers**, not hidden behind paywalls or proprietary platforms.



**🇹🇷 (Türkçe)**

**Neden CoordinateLookup’u geliştirdik?**  
Çünkü ihtiyacımız vardı — ama yoktu.

.NET ile çalışan, coğrafi koordinatları Türkiye'nin idari yapısıyla eşleştiren bir API ya **çok pahalıydı**, **ya yetersizdi**, ya da **entegrasyonu zordu**. Ticari servisler yüksek ücret talep ediyor, açık veriler dağınık, eksik ve güncelliğini yitirmiş oluyordu. Kısacası, “çalışır” bir çözüm yoktu.

Bu yüzden ihtiyacımız olan aracı kendimiz geliştirdik — ve herkesin kullanabilmesi için açık kaynak haline getirdik.
CoordinateLookup, şu inançla doğdu: **geliştiricilerin ihtiyaç duyduğu temel konum araçları herkesin erişimine açık olmalı**, ödeme duvarlarının ardına saklanmamalı.

---

## Features (Özellikler)

**🇬🇧 (English)**

1.  Retrieve Province and District information based on Latitude and Longitude inputs.
2.  Get a list of all Provinces in Turkey.
3.  Retrieve detailed information for a specific Province by its ID (including Plate Number, Coordinates, Latitude, Longitude).
4.  Retrieve detailed information for a specific Province along with all its associated Districts by Province ID.
5.  Retrieve a list of Districts belonging to a specific Province by its ID (including Name, Coordinates, Latitude, Longitude).
6.  Retrieve detailed information for a specific District along with all its associated Towns by District ID.
7.  Retrieve a list of Towns belonging to a specific District by its ID (including Id, Name, Zip Code).
8.  Retrieve detailed information for a specific Town along with all its associated Neighbourhoods by Town ID.
9.  Retrieve a list of Neighbourhoods belonging to a specific Town by its ID.
10. Calculate the distance (in kilometers) between two Provinces using their IDs.
11. Calculate the distance (in kilometers) between two Districts using their IDs.
12. Calculate the distance (in kilometers) between two Provinces using their names.
13. Calculate the distance (in kilometers) between two Districts using their names.

**🇹🇷 (Türkçe)**

1.  Girilen Enlem ve Boylam bilgilerine göre İl ve İlçe bilgilerini alma.
2.  Türkiye'deki tüm İllerin listesini alma.
3.  Belirli bir İl'e ait ID ile detaylı bilgileri (Plaka No, Koordinatlar, Enlem, Boylam dahil) alma.
4.  Belirli bir İl'e ait ID ile İl'in tüm bilgilerini ve ilişkili tüm İlçelerini alma.
5.  Belirli bir İl'e ait ID ile o İl'e bağlı İlçelerin listesini (İsim, Koordinatlar, Enlem, Boylam dahil) alma.
6.  Belirli bir İlçe'ye ait ID ile İlçe'nin tüm bilgilerini ve ilişkili tüm Beldelerini alma.
7.  Belirli bir İlçe'ye ait ID ile o İlçe'ye bağlı Beldelerin listesini (Id, İsim, Posta Kodu dahil) alma.
8.  Belirli bir Belde'ye ait ID ile Belde'nin tüm bilgilerini ve ilişkili tüm Mahallelerini alma.
9.  Belirli bir Belde'ye ait ID ile o Belde'ye bağlı Mahallelerin listesini alma.
10. ID'lerini kullanarak iki İl arasındaki mesafeyi (kilometre cinsinden) hesaplama.
11. ID'lerini kullanarak iki İlçe arasındaki mesafeyi (kilometre cinsinden) hesaplama.
12. İsimlerini kullanarak iki İl arasındaki mesafeyi (kilometre cinsinden) hesaplama.
13. İsimlerini kullanarak iki İlçe arasındaki mesafeyi (kilometre cinsinden) hesaplama.

---

## Technologies Used (Kullanılan Teknolojiler)

- **Programming Language:** C#
- **Framework:** .NET 9.0
- **ORM:** Entity Framework Core
- **Database:** PostgreSQL
- **Data Import:** `Location.json` processing for seeding database
- **API Testing:** Postman
- **API Documentation:** OpenAPI / Swagger
- **Architecture:** Layered Architecture Principles
- **Validation:** FluentValidation
- **Design Principles:** SOLID Principles
- **Deployment:** Docker support

---

## Getting Started (Başlarken)

**🇬🇧 (English)**

Follow these instructions to get the API up and running on your local machine.

**🇹🇷 (Türkçe)**

API'yi yerel makinenizde çalışır duruma getirmek için aşağıdaki talimatları izleyin.

### Prerequisites (Önkoşullar)

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) or later
- [PostgreSQL](https://www.postgresql.org/download/) Database Server
- [Docker](https://www.docker.com/get-started) (Optional, for containerized deployment)
- Git

### Installation & Setup (Kurulum)

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/serkanozbeykurucu/CoordinateLookup.git
    cd CoordinateLookup # Navigate into the project directory
    ```

2.  **Configure Database Connection:**

    - Ensure your PostgreSQL server is running.
    - Create a database (e.g., `coordinate_lookup_db`).
    - Update the database connection string in `appsettings.json` (or `appsettings.Development.json`) within the API project.
      ```json
      {
        "ConnectionStrings": {
          "CoordinateLookupDB": "Host=localhost;Port=5432;Database=coordinate_lookup_db;Username=your_username;Password=your_password;"
        }
      }
      ```

3.  **Apply Migrations & Seed Data:**
    - Navigate to the project directory containing the `.csproj` file (likely the main API project).
    - Run Entity Framework Core migrations to create the database schema:
      ```bash
      dotnet ef database update
      ```
    - The application should be configured to automatically seed the data from `Location.json` upon first startup or via a specific seeding mechanism you implemented. Ensure the `Location.json` file is correctly placed and accessible by the application during startup or the seeding process.

### Running the API (API'yi Çalıştırma)

1.  **Using .NET CLI:**

    - Navigate to the API project directory.
    - Run the application:
      ```bash
      dotnet run
      ```

2.  **Using Docker (if Dockerfile is configured):**
    - Build the Docker image:
      ```bash
      docker build -t coordinatelookup-api .
      ```
    - Run the Docker container (make sure to map ports and potentially pass connection strings via environment variables):
      ```bash
      docker run -p 7047:8080 -e ConnectionStrings__CoordinateLookupDB="<your_connection_string>" coordinatelookup-api
      ```
      _(Adjust the host port `7047` and container port `8080` as needed based on your Dockerfile configuration)_

Once running, the API should be accessible at `https://localhost:7047` (or the configured port). You can access the Swagger UI for interactive documentation at `https://localhost:7047/swagger`.

---

## API Endpoints (API Uç Noktaları)

**🇬🇧 (English)** Base URL for local development: `https://localhost:7047/api`
**🇹🇷 (Türkçe)** Yerel geliştirme için temel URL: `https://localhost:7047/api`

### 1. Get Geographical Location By Latitude And Longitude

- **(EN)** Retrieves the Province and District corresponding to the given latitude and longitude.
- **(TR)** Verilen enlem ve boylama karşılık gelen İl ve İlçe bilgisini getirir.
- **Method:** `GET`
- **URL:** `/Location/GetGeographicalLocationByLatitudeAndLongitudeAsync`
- **Request Body:**
  ```json
  {
    "latitude": 37.0147201,
    "longitude": 35.3136997
  }
  ```
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Location retrieved successfully.",
    "data": {
      "province": "Adana",
      "district": "Seyhan"
    }
  }
  ```

### 2. Get All Provinces

- **(EN)** Retrieves a list of all provinces in Turkey.
- **(TR)** Türkiye'deki tüm illerin listesini getirir.
- **Method:** `GET`
- **URL:** `/Province/GetAllProvinces`
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Provinces retrieved successfully.",
    "data": [
      {
        "id": 1,
        "name": "Adana",
        "plateNumber": 1,
        "plateNumber": "37.0000, 35.3250",
        "latitude": 37.0,
        "longitude": 35.325
      },
      {
        "id": 2,
        "name": "Adıyaman",
        "plateNumber": 2,
        "coordinates": "37.7644, 38.2763",
        "latitude": 37.7644,
        "longitude": 38.2763
      }
      // ... other provinces
    ]
  }
  ```

### 3. Get Province By Id

- **(EN)** Retrieves detailed information for a specific province using its ID.
- **(TR)** ID'sini kullanarak belirli bir ilin detaylı bilgilerini getirir.
- **Method:** `GET`
- **URL:** `/Province/GetProvinceById?provinceId=1`
- **Query Parameter:** `provinceId` (integer) - The ID of the province.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Province retrieved successfully.",
    "data": {
      "province": "Adana",
      "plateNumber": 1,
      "coordinates": "37.0000, 35.3250",
      "latitude": 37.0,
      "longitude": 35.325
    }
  }
  ```

### 4. Get Province With Districts

- **(EN)** Retrieves detailed information for a specific province, including a list of its districts.
- **(TR)** Belirli bir ilin detaylı bilgilerini ve bağlı ilçelerinin listesini getirir.
- **Method:** `GET`
- **URL:** `/Province/GetProvinceWithDistricts?provinceId=1`
- **Query Parameter:** `provinceId` (integer) - The ID of the province.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Province with districts retrieved successfully.",
    "data": {
      "province": "Adana",
      "plateNumber": 1,
      "coordinates": "37.0000, 35.3250",
      "latitude": 37.0,
      "longitude": 35.325,
      "districts": [
        {
          "district": "Seyhan",
          "coordinates": "36.9875, 35.3059",
          "latitude": 36.9875,
          "longitude": 35.3059
        },
        {
          "district": "Yüreğir",
          "coordinates": "36.9744, 35.3592",
          "latitude": 36.9744,
          "longitude": 35.3592
        }
        // ... other districts in Adana
      ]
    }
  }
  ```

### 5. Get Districts By Province Id

- **(EN)** Retrieves a list of districts belonging to a specific province ID.
- **(TR)** Belirli bir il ID'sine ait ilçelerin listesini getirir.
- **Method:** `GET`
- **URL:** `/District/GetDistrictsByProvinceId?provinceId=1`
- **Query Parameter:** `provinceId` (integer) - The ID of the province.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Districts retrieved successfully.",
    "data": [
      {
        "id": 12,
        "name": "Seyhan",
        "coordinates": "36.9875, 35.3059",
        "latitude": 36.9875,
        "longitude": 35.3059
      },
      {
        "id": 13,
        "name": "Tufanbeyli",
        "coordinates": "38.2633, 36.2206",
        "latitude": 38.2633,
        "longitude": 36.2206
      }
      // ... other districts in Adana
    ]
  }
  ```

### 6. Get District With Towns

- **(EN)** Retrieves detailed information for a specific district, including a list of its towns.
- **(TR)** Belirli bir ilçenin detaylı bilgilerini ve bağlı beldelerinin listesini getirir.
- **Method:** `GET`
- **URL:** `/District/GetDistrictWithTowns?districtId=12`
- **Query Parameter:** `districtId` (integer) - The ID of the district.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "District with towns retrieved successfully.",
    "data": {
      "district": "Seyhan",
      "coordinates": "36.9875, 35.3059",
      "latitude": 36.9875,
      "longitude": 35.3059,
      "towns": [
        {
          "town": "Akkapı",
          "zipCode": "01040"
        },
        {
          "town": "Denizli",
          "zipCode": "01130"
        }
        // ... other towns in Seyhan
      ]
    }
  }
  ```
  _(Note: Town data might vary significantly based on the source `Location.json`)_

### 7. Get Towns By District Id

- **(EN)** Retrieves a list of towns belonging to a specific district ID.
- **(TR)** Belirli bir ilçe ID'sine ait beldelerin listesini getirir.
- **Method:** `GET`
- **URL:** `/Town/GetTownsByDistrictId?districtId=12`
- **Query Parameter:** `districtId` (integer) - The ID of the district.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Towns retrieved successfully.",
    "data": [
      {
        "id": 32,
        "name": "Akkapı",
        "zipCode": "01040"
      },
      {
        "id": 33,
        "name": "Denizli",
        "zipCode": "01130"
      }
      // ... other towns in Seyhan
    ]
  }
  ```

### 8. Get Town With Neighbourhoods

- **(EN)** Retrieves detailed information for a specific town, including a list of its neighbourhoods.
- **(TR)** Belirli bir beldenin detaylı bilgilerini ve bağlı mahallelerinin listesini getirir.
- **Method:** `GET`
- **URL:** `/Town/GetTownWithNeighbourhoods?townId=52`
- **Query Parameter:** `townId` (integer) - The ID of the town.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Town with neighbourhoods retrieved successfully.",
    "data": {
      "town": "Ziyapaşa",
      "zipCode": "01140",
      "neighbourhoods": [
        {
          "name": "Gazipaşa mah"
        },
        {
          "name": "Namık kemal mah"
        }
        // ... other neighbourhoods in Town Ziyapasa
      ]
    }
  }
  ```

### 9. Get Neighbourhoods By Town Id

- **(EN)** Retrieves a list of neighbourhoods belonging to a specific town ID.
- **(TR)** Belirli bir belde ID'sine ait mahallelerin listesini getirir.
- **Method:** `GET`
- **URL:** `/Neighbourhood/GetNeighbourhoodsByTownId?townId=52`
- **Query Parameter:** `townId` (integer) - The ID of the town.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Neighbourhoods retrieved successfully.",
    "data": [
      {
        "name": "Gazipaşa mah"
      },
      {
        "name": "Namık kemal mah"
      }
      // ... other neighbourhoods in Town Ziyapasa
    ]
  }
  ```

### 10. Get Distance Between Provinces (by ID)

- **(EN)** Calculates the approximate distance (in kilometers) between the centers of two provinces using their IDs.
- **(TR)** ID'lerini kullanarak iki ilin merkezleri arasındaki yaklaşık mesafeyi (kilometre cinsinden) hesaplar.
- **Method:** `GET`
- **URL:** `/Distance/GetDistanceBetweenProvinces?firstProvinceId=1&secondProvinceId=80`
- **Query Parameters:**
  - `firstProvinceId` (integer) - ID of the first province.
  - `secondProvinceId` (integer) - ID of the second province.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Distance calculated successfully.",
    "data": {
      "firstLocation": null,
      "secondLocation": null,
      "distanceInKm": 82.52549209633295
    }
  }
  ```

### 11. Get Distance Between Districts (by ID)

- **(EN)** Calculates the approximate distance (in kilometers) between the centers of two districts using their IDs.
- **(TR)** ID'lerini kullanarak iki ilçenin merkezleri arasındaki yaklaşık mesafeyi (kilometre cinsinden) hesaplar.
- **Method:** `GET`
- **URL:** `/Distance/GetDistanceBetweenDistricts?firstDistrictId=3&secondDistrictId=12`
- **Query Parameters:**
  - `firstDistrictId` (integer) - ID of the first district.
  - `secondDistrictId` (integer) - ID of the second district.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Distance calculated successfully.",
    "data": {
        "firstLocation": "Çukurova",
        "secondLocation": "Seyhan",
        "distanceInKm": 18.485959177751464
    }
  }
  ```

### 12. Get Distance Between Provinces (by Name)

- **(EN)** Calculates the approximate distance (in kilometers) between the centers of two provinces using their names (case-insensitive).
- **(TR)** İsimlerini kullanarak (büyük/küçük harf duyarsız) iki ilin merkezleri arasındaki yaklaşık mesafeyi (kilometre cinsinden) hesaplar.
- **Method:** `GET`
- **URL:** `/Distance/GetDistanceByProvinceNames?firstProvince=ADANA&secondProvince=mersin`
- **Query Parameters:**
  - `firstProvince` (string) - Name of the first province.
  - `secondProvince` (string) - Name of the second province.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Distance calculated successfully.",
    "data": {
        "firstLocation": "Adana",
        "secondLocation": "Mersin",
        "distanceInKm": 66.79340174222935
    }
  }
  ```

### 13. Get Distance Between Districts (by Name)

- **(EN)** Calculates the approximate distance (in kilometers) between the centers of two districts using their names (case-insensitive).
- **(TR)** İsimlerini kullanarak (büyük/küçük harf duyarsız) iki ilçenin merkezleri arasındaki yaklaşık mesafeyi (kilometre cinsinden) hesaplar.
- **Method:** `GET`
- **URL:** `/Distance/GetDistanceByDistrictNames?firstDistrict=Seyhan&secondDistrict=Çukurova`
- **Query Parameters:**
  - `firstDistrict` (string) - Name of the first district.
  - `secondDistrict` (string) - Name of the second district.
- **Example Response:**
  ```json
  {
    "responseCode": 200,
    "message": "Distance calculated successfully.",
    "data": {
        "firstLocation": "Seyhan",
        "secondLocation": "Çukurova",
        "distanceInKm": 18.485959177751464
    }
  }
  ```

---

## References (Referanslar)

- **Location Data Source:** The primary source for administrative boundaries, coordinates, and relationships is the `Location.json` file included in the project or referenced during development.
- **Inspirational Projects:**
  - https://github.com/caglarsarikaya/turkey-geolocations
  - https://github.com/melihkorkmaz/il-ilce-mahalle-geolocation-rest-api
  - https://simplemaps.com/country/tr/
  - https://gist.github.com/abdullahoguk/ee03c26a23dca6eda9c480b4967e77b6
  - https://gist.github.com/ismailbaskin/2492196
    
---

## Contributing (Katkıda Bulunma)

**🇬🇧 (English)** Contributions are welcome! Please feel free to submit pull requests or open issues for bugs, feature requests, or improvements.

**🇹🇷 (Türkçe)** Katkılarınız memnuniyetle karşılanır! Hatalar, özellik istekleri veya iyileştirmeler için lütfen pull request gönderin veya issue açın.

---

## License (Lisans)

**🇬🇧 (English)** This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

**🇹🇷 (Türkçe)** Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakınız.