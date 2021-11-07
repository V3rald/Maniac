using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model
{
    class Token
    {
        [JsonProperty("token_type")]
        public string TokenType { get; private set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }
    }
}
