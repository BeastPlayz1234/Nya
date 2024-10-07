using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nya.Entries
{
    internal class WebAPIEntries
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}