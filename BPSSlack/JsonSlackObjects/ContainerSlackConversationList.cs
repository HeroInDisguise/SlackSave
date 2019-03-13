using Newtonsoft.Json;
using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
{/// <summary>
/// Dies ist der Container für SlackChannels die abgerufen werden können
/// </summary>
    public class ContainerSlackConversationList
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("ims")]
        public List<Im> Ims { get; set; }
    }
     
    public class Im
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("is_im")]
        public bool IsIm { get; set; }

        [JsonProperty("is_org_shared")]
        public bool IsOrgShared { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("is_user_deleted")]
        public bool IsUserDeleted { get; set; }
    }
}