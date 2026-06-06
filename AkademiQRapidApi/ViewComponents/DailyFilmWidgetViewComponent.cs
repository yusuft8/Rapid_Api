using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace AkademiQRapidApi.ViewComponents
{
    public class DailyFilmWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://rottentomato.p.rapidapi.com/?name=Tangerines"),
                Headers =
    {
        { "x-rapidapi-key", "a587c278cfmsh772574fdc79a834p178403jsna5ef07f7ed59" },
        { "x-rapidapi-host", "rottentomato.p.rapidapi.com" },
    },
            };


            var response = await client.SendAsync(request);


            var jsonBody = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<Models.DailyFilmModel.Rootobject>(jsonBody);


            return View(values);
        }

    }
}
