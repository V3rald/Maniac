using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac
{
    public class Config
    {
        [JsonProperty("token")]
        public string token { get; private set; }
        [JsonProperty("prefix")]
        public string prefix { get; private set; }
    }
}
