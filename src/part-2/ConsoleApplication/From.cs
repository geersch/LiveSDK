using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class From
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }   
    }
}