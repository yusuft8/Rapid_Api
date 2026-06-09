# Akademiq API Dashboard 🚀

Akademiq API Dashboard, farklı veri kaynaklarını tek bir merkezde toplayıp anlamlandıran, yalnızca veri göstermekle kalmayıp aynı zamanda veriyi işleyen ve kullanıcıyla dinamik etkileşime giren .NET 9 tabanlı akıllı bir yönetim panelidir.

Bu proje, **AkademiQ Ai Business School Backend Eğitimi** kapsamında geliştirilmiştir.

---

## 📌 Proje Yaklaşımı & Amacı

Projenin temel amacı; finans, spor, medya ve içerik gibi farklı API servislerinden gelen verileri asenkron süreçlerle eş zamanlı olarak çekmek, modern bir arayüz ile kullanıcıya sunmak ve sisteme yapay zeka destekli analiz kabiliyeti kazandırmaktır. 

---


## 📊 Entegre Edilen API'ler ve Veri Başlıkları

Projede kullanılan tüm dinamik veriler, modüler veri kartları (widgets / components) halinde tasarlanmış olup aşağıdaki servisler üzerinden beslenmektedir:

* 🌦️ **Hava Durumu:** Open-Meteo API ile haftalık tahmin ve detaylı analiz verileri.
* 💱 **Finans:** Döviz kurları, kripto para fiyatları ve güncel akaryakıt verilerinin anlık takibi (RapidAPI).
* ⚽ **Spor:** Canlı skorlar, güncel lig verileri ve futbol maçı sonuçları (API-Football / RapidAPI).
* 📰 **Haberler:** Güncel gelişmelerin kategorize edilmiş 3 adet dinamik haber içeriği (NewsAPI).
* 🎬 **Medya & Eğlence:** Günün en popüler filmi (TMDB) ve en çok dinlenen şarkısı (Deezer / Music API).
* 💬 **Motivasyon & Dil:** Günlük motivasyon sözleri (FavQs API) ve entegre Google Translate API ile anlık Türkçe çeviri desteği.
* 🍳 Günün Yemek Önerisi: Yemek tarifleri API'si (RapidAPI) üzerinden çekilen günlük dinamik yemek önerileri ve tarif detayları.  
---

## 🧠 Teknik Mimari ve Teknolojiler

Proje, temiz kod prensiplerine ve sürdürülebilir mimari standartlarına uygun olarak geliştirilmiştir:

* **Framework:** ASP.NET Core MVC (.NET 9.0)
* **Mimari:** N-Tier Architecture (Çok Katmanlı Mimari) – Sürdürülebilir, gevşek bağlı (loosely coupled) ve Dependency Injection odaklı yapı.
* **Veri Yönetimi:** Entity Framework Core (Code-First yaklaşımı ile esnek veritabanı yönetimi).
* **Performans:** Çoklu API isteklerinde sistemin kilitlenmesini önlemek adına tamamen `async/await` asenkron programlama yapısı.
* **Arayüz Tasarımı:** TailwindCSS ile geliştirilmiş Cyberpunk temalı (glassmorphism ve neon efektli), tamamen responsive (mobil uyumlu) UI.
* **Kullanıcı Deneyimi:** Sayfa yenilenmeden kesintisiz veri akışı için AJAX & Fetch API entegrasyonu.

---

## 🛠️ Kurulum ve Çalıştırma Talimatları

Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

### 1. Ön Gereksinimler
* Bilgisayarınızda **.NET 9.0 SDK** yüklü olmalıdır.
* Veritabanı işlemleri için tercih ettiğiniz SQL Server (veya ilgili DB provider) kurulu olmalıdır.

### 2. Repoyu Klonlayın
```bash
git clone [https://github.com/yusuft8/Rapid_Api.git](https://github.com/yusuft8/Rapid_Api.git)
cd Rapid_Api
