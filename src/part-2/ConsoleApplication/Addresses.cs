using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    [JsonDictionary]
    public class Addresses : Dictionary<string, Address>
    {
    }
}