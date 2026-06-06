using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace AkademiQRapidApi.ViewComponents
{
    public class ConvertWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(decimal amount = 1)
        {
            if (amount <= 0) amount = 1;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fast-price-exchange-rates.p.rapidapi.com/api/v1/convert?amount=1&base_currency=TRY&quote_currency=USD,BTC,GBP,JPY,CAD,AUD,CHF,EUR"),
                Headers =
        {
            { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
            { "x-rapidapi-host", "fast-price-exchange-rates.p.rapidapi.com" },
        },
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode(); // Hata varsa catch bloğuna düşer
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    var rates = JsonSerializer.Deserialize<ConvertViewmodel.Rootobject>(jsonBody);

                    if (rates != null && rates.to != null)
                    {
                        // Çarpma işlemi öncesi tipleri kontrol et. 
                        // Eğer modelin double ise (double)amount kullan.
                        rates.to.USD *= (float)(double)amount;
                        rates.to.EUR *= (float)(double)amount;
                        rates.to.GBP *= (float)(double)amount;
                        // ... Diğerlerini de aynı şekilde ekle

                        return View(rates);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata loglanabilir: ex.Message
                return View(new ConvertViewmodel.Rootobject()); // Boş model dönerek sayfanın çökmesini engelle
            }

            return View();
        }
    }

            
}













 