using AkademiQRapidApi.Models;
 using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace AkademiQRapidApi.ViewComponents
{
    public class NewsWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://google-news13.p.rapidapi.com/latest?lr=tr-TR"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "google-news13.p.rapidapi.com" },
    },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();

                    var values = JsonSerializer.Deserialize<NewsViewModel.Rootobject>(jsonBody);
                    return View(values);
                }
            }
            return View();
        }
    }
}
