using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using static AkademiQRapidApi.Models.BitcoinViewModel;

namespace AkademiQRapidApi.ViewComponents
{
    public class BitcoinWidgetViewComponent : ViewComponent
    {
    public async Task<IViewComponentResult> InvokeAsync()
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

             var top1Values = values.Take(3).ToList();

            return View(top1Values);

        }
    }
}
