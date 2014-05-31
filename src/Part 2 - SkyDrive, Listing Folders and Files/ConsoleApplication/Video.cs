using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Video : FileSystemInfo
    {
        [JsonProperty(PropertyName = "comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty(PropertyName = "comments_enabled")]
        public bool CommentsEnabled { get; set; }

        [JsonProperty(PropertyName = "tags_count")]
        public int TagsCount { get; set; }

        [JsonProperty(PropertyName = "comments_enabled")]
        public bool TagsEnabled { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
    }
}