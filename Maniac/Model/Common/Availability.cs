using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Common
{
    public class Availability
    {
        [JsonProperty("download_disabled")]
        public bool DownloadDisabled { get; set; }

        [JsonProperty("more_information")]
        public object MoreInformation { get; set; }
    }
}
