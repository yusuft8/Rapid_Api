namespace AkademiQRapidApi.Models
{
    public class ConvertViewmodel
    {

        public class Rootobject
        {
            public string from { get; set; }
            public float amount { get; set; }
            public To to { get; set; }
        }

        public class To
        {
            public float USD { get; set; }
            public float EUR { get; set; }
            public float GBP { get; set; }
            public float JPY { get; set; }
            public float CAD { get; set; }
            public float AUD { get; set; }
            public float CHF { get; set; }
            public float BTC { get; set; }
        }

        // Her API çağrısının tek sonucu için yardımcı sınıf
        public class SingleResult
        {
            public string from { get; set; }
            public To to { get; set; }
        }


    }
}
