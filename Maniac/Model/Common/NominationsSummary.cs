using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maniac.Model.Common
{
    public class NominationsSummary
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("required")]
        public long NominationsSummaryRequired { get; set; }
    }
}
