using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Position
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}