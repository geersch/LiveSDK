using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Employer
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}