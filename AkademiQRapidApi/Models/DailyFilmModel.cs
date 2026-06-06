namespace AkademiQRapidApi.Models
{
    public class DailyFilmModel
    {


        public class Rootobject
        {
            public string description { get; set; }
            public Recommendation[] recommendations { get; set; }
            public string title { get; set; }
        }

        public class Recommendation
        {
            public int audience_score { get; set; }
            public int critics_score { get; set; }
            public string ems_id { get; set; }
            public string image_url { get; set; }
            public string media_type { get; set; }
            public string media_url { get; set; }
            public string title { get; set; }
        }

    }
}

