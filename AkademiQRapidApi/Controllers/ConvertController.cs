using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;


using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AkademiQRapidApi.Controllers
{
    public class ConvertController : Controller
    {
        public async Task<IActionResult> Index(float amount = 1)
        {
            if (amount <= 0) amount = 1;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fast-price-exchange-rates.p.rapidapi.com/api/v1/convert?amount=1&base_currency=TRY&quote_currency=USD%2CBTC%2CGBP%2CJPY%2CCAD%2CAUD%2CCHF%2CEUR"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "fast-price-exchange-rates.p.rapidapi.com" },
    },
            };


            var response = await client.SendAsync(request);
            var jsonBody = await response.Content.ReadAsStringAsync();
            var rates = JsonSerializer.Deserialize<ConvertViewmodel.Rootobject>(jsonBody);

            if (rates?.to != null)
            {
                // Kullanıcının girdiği miktarla çarp
                rates.to.USD *= amount;
                rates.to.EUR *= amount;
                rates.to.GBP *= amount;
                rates.to.JPY *= amount;
                rates.to.CAD *= amount;
                rates.to.AUD *= amount;
                rates.to.CHF *= amount;
                rates.to.BTC *= amount;
            }

            if (rates != null) rates.amount = amount;

            return View(rates);
        }
    }
}