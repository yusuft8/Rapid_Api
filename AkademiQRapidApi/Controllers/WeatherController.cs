using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
namespace AkademiQRapidApi.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
         
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city?city=Istanbul&lang=TR"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };

            var response = await client.SendAsync(request);
            var jsonBody = await response.Content.ReadAsStringAsync();
            var values = JsonSerializer.Deserialize<Models.WeatherVievModel.Rootobject>(jsonBody);

            // Fahrenheit → Celsius dönüşümü
            if (values?.main != null)
            {
                values.main.temp = (values.main.temp - 32) * 5 / 9;
                values.main.temp_min = (values.main.temp_min - 32) * 5 / 9;
                values.main.temp_max = (values.main.temp_max - 32) * 5 / 9;
                values.main.feels_like = (values.main.feels_like - 32) * 5 / 9;
            }

            return View(values);
        }
    }
}
