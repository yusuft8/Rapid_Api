using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AkademiQRapidApi.ViewComponents
{
    public class MotivasyonWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://quotes-api12.p.rapidapi.com/quotes"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "quotes-api12.p.rapidapi.com" },
    },
            };

            var response = await client.SendAsync(request);


            var jsonBody = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<Models.MotivasyonViewModel.Rootobject>(jsonBody);


            return View(values);

        }
    }
}
