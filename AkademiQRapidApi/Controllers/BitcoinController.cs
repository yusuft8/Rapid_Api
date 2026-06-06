using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AkademiQRapidApi.Controllers
{
    public class BitcoinController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://binance43.p.rapidapi.com/ticker/24hr"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "binance43.p.rapidapi.com" },
    },
            };

            var response = await client.SendAsync(request);


            var jsonBody = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<List<Models.BitcoinViewModel.Class1>>(jsonBody);

            // Sadece ilk 50 veriyi alıp View'a gönderiyoruz
            var top50Values = values.Take(50).ToList();

            return View(top50Values);
        }
    }
}
