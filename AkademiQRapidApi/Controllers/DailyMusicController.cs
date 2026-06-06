
using AkademiQRapidApi.Models; // Modelinizin bulunduğu namespace'i eklemeyi unutmayın
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AkademiQRapidApi.Controllers
{
    public class DailyMusicController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/top_200_tracks?country=TR&period=daily"),
                Headers =
                {
                    // DİKKAT: Buradaki boşluğu kendi RapidAPI anahtarınızla doldurmalısınız
                    { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
                    { "x-rapidapi-host", "spotify81.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    // Tüm listeyi deserialize ediyoruz
                    var values = JsonSerializer.Deserialize<List<DailyMusicModel.Class1>>(jsonBody);
                    // View'a tüm listeyi gönderiyoruz
                    return View(values);
                }
            }
            return View();
 
        }
    }
}