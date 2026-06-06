namespace AkademiQRapidApi.Models
{
    public class YoutubeViewModel
    {

        public class Rootobject
        {
            public int progress { get; set; }
            public string title { get; set; }
            public string msg { get; set; }
            public float duration { get; set; }
            public string status { get; set; }
            public int filesize { get; set; }
            public string link { get; set; }
            public int pc { get; set; }
        }

    }
}
