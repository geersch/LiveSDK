using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SkyDrive
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<Folder> Folders { get; set; }
    }
}