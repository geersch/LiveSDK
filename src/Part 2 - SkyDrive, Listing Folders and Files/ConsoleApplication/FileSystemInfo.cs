using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FileSystemInfo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "from")]
        public From From { get; set; }

        [JsonProperty(PropertyName = "parent_id")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedTime { get; set; }

        [JsonProperty(PropertyName = "updated_time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty(PropertyName = "upload_location")]
        public string UploadLocation { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}