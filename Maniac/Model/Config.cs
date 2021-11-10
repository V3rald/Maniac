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
        [JsonProperty("client_id")]
        public string ClientId { get; private set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }
    }
}
