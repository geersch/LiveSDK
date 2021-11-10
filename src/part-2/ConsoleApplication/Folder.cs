using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Folder : FileSystemInfo
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "is_embeddable")]
        public bool IsEmbeddable { get; set; }
    }
}
