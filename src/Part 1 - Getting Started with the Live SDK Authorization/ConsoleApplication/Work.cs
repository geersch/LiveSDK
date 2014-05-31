using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Work
    {
        [JsonProperty(PropertyName = "employer")]
        public Employer Employer { get; set; }

        [JsonProperty(PropertyName = "position")]
        public Position Position { get; set; }
    }
}