using System;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Photo : FileSystemInfo
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("when_taken")]
        public DateTime? WhenTaken { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}