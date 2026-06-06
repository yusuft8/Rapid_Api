namespace AkademiQRapidApi.Models
{
    public class DailyMusicModel
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public Chartentrydata chartEntryData { get; set; }
            public bool missingRequiredFields { get; set; }
            public Trackmetadata trackMetadata { get; set; }
            public string chartDate { get; set; }
            public string requestedDate { get; set; }
            public int daysBack { get; set; }
        }

        public class Chartentrydata
        {
            public int currentRank { get; set; }
            public int previousRank { get; set; }
            public int peakRank { get; set; }
            public int appearancesOnChart { get; set; }
            public int consecutiveAppearancesOnChart { get; set; }
            public Rankingmetric rankingMetric { get; set; }
            public string entryStatus { get; set; }
            public string peakDate { get; set; }
            public int entryRank { get; set; }
            public string entryDate { get; set; }
        }

        public class Rankingmetric
        {
            public string value { get; set; }
            public string type { get; set; }
        }

        public class Trackmetadata
        {
            public string trackName { get; set; }
            public string trackUri { get; set; }
            public string displayImageUri { get; set; }
            public Artist[] artists { get; set; }
            public object[] producers { get; set; }
            public Label[] labels { get; set; }
            public object[] songWriters { get; set; }
            public string releaseDate { get; set; }
        }

        public class Artist
        {
            public string name { get; set; }
            public string spotifyUri { get; set; }
            public string externalUrl { get; set; }
        }

        public class Label
        {
            public string name { get; set; }
            public string spotifyUri { get; set; }
            public string externalUrl { get; set; }
        }

    }
}
