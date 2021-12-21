using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Auth
{
    public class OsuToken
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }

        public OsuToken(string clientId, string clientSecret, string grantType, string scope)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            GrantType = grantType;
            Scope = scope;
        }
    }
}