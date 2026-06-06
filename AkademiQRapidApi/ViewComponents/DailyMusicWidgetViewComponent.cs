using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AkademiQRapidApi.ViewComponents
{
    public class DailyMusicWidget : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spotify81.p.rapidapi.com/top_200_tracks?country=TR&period=daily"),
                Headers =
                {
                    { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
                    { "x-rapidapi-host", "spotify81.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    var values = JsonSerializer.Deserialize<List<DailyMusicModel.Class1>>(jsonBody);

                    // Sadece 1 numarayı alıp widget view'ına gönderiyoruz
                    var topSong = values?.FirstOrDefault();
                    return View(topSong);
                }
            }
            return View();
        }
    }
}