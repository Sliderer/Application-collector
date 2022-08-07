using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace App_collector
{
    public class File
    {
        [JsonProperty("path")]
        internal string path { get; set; }

        [JsonProperty("fileName")]
        internal string filename { get; set; }

        [JsonProperty("type")]
        internal string type { get; set; }
    }
}
