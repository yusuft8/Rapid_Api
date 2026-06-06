using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQRapidApi.ViewComponents
{
    public class FootballScoreWidgetViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free-api-live-football-data.p.rapidapi.com/football-current-live"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "free-api-live-football-data.p.rapidapi.com" },
    },
            };

            var response = await client.SendAsync(request);


            var jsonBody = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<Models.FootballscoreViewModel.Rootobject>(jsonBody);


            return View(values);
        }
      }
}
