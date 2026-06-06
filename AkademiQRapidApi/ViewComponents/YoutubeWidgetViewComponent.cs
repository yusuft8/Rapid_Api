using AkademiQRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AkademiQRapidApi.ViewComponents
{
    public class YoutubeWidgetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://youtube-mp36.p.rapidapi.com/dl?id={id}"),
                Headers =
    {
        { "x-rapidapi-key", "073f074a6cmshfd75741e3ecc8bfp1af40fjsna762b5697ae4" },
        { "x-rapidapi-host", "youtube-mp36.p.rapidapi.com" },
    },
            };
            var response = await client.SendAsync(request);


            var jsonBody = await response.Content.ReadAsStringAsync();


            var values = JsonSerializer.Deserialize<YoutubeViewModel.Rootobject>(jsonBody);
            //json olan bir ifadeyi nesneye dönüştürmek için deserialize işlemi yapıyoruz
            //nesneden jsona dönüştürmek için serialize işlemi yapıyoruz
            //bu işlemi yaparken jsonun yapısına uygun bir class yapısı oluşturuyoruz
            //bu class yapısını oluşturduktan sonra jsonu deserialize ederek nesneye dönüştürüyoruz 


            return View(values);


        }
    } 
}