using Newtonsoft.Json;
using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
{/// <summary>
/// Dies ist der Container für SlackChannels die abgerufen werden können
/// </summary>
    public partial class ContainerSlackChannelList
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }
     
    public partial class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_channel")]
        public bool IsChannel { get; set; }

        [JsonProperty("is_group")]
        public bool IsGroup { get; set; }

        [JsonProperty("is_im")]
        public bool IsIm { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_general")]
        public bool IsGeneral { get; set; }

        [JsonProperty("unlinked")]
        public long Unlinked { get; set; }

        [JsonProperty("name_normalized")]
        public string NameNormalized { get; set; }

        [JsonProperty("is_shared")]
        public bool IsShared { get; set; }

        [JsonProperty("is_ext_shared")]
        public bool IsExtShared { get; set; }

        [JsonProperty("is_org_shared")]
        public bool IsOrgShared { get; set; }

        [JsonProperty("pending_shared")]
        public List<object> PendingShared { get; set; }

        [JsonProperty("is_pending_ext_shared")]
        public bool IsPendingExtShared { get; set; }

        [JsonProperty("is_member")]
        public bool IsMember { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_mpim")]
        public bool IsMpim { get; set; }

        [JsonProperty("topic")]
        public Purpose Topic { get; set; }

        [JsonProperty("purpose")]
        public Purpose Purpose { get; set; }

        [JsonProperty("previous_names")]
        public List<object> PreviousNames { get; set; }

        [JsonProperty("num_members")]
        public long NumMembers { get; set; }
    }
    public partial class Purpose
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("last_set")]
        public long LastSet { get; set; }
    }
}