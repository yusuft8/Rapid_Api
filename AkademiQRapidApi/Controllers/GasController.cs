using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AkademiQRapidApi.Controllers
{
    public class GasController : Controller
    {
        public async Task<IActionResult> Index()
        {


     
            var client = new HttpClient();//istek atmak için client oluşturduk
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };


            var response = await client.SendAsync(request);


            var jsonBody  = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<Models.GasViewModel.Rootobject>(jsonBody);
            //json olan bir ifadeyi nesneye dönüştürmek için deserialize işlemi yapıyoruz
            //nesneden jsona dönüştürmek için serialize işlemi yapıyoruz
            //bu işlemi yaparken jsonun yapısına uygun bir class yapısı oluşturuyoruz
            //bu class yapısını oluşturduktan sonra jsonu deserialize ederek nesneye dönüştürüyoruz 
            if (values?.result == null)
            {
                values = new Models.GasViewModel.Rootobject { result = new Models.GasViewModel.Result[0] };
            }

            return View(values);
        }
    }
}
 

 