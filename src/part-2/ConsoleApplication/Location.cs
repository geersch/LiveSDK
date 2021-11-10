using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Location
    {
        [JsonProperty("latitude ")]
        public double Lattitude { get; set; }

        [JsonProperty("longitude ")]
        public double Longitude { get; set; }
    }
}