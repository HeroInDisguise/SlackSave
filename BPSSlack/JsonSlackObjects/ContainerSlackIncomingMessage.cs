using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
 
{/// <summary>
/// Dies ist der Container in den Nachrichten und deren Inhalte gespeichert werden, wenn man diese von einem Channel abruft.
/// </summary>
    public class ContainerSlackIncomingMessage
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("response_metadata")]
        public ResponseMetadata ResponseMetadata { get; set; }
    }

    public class Message
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Attachment> Attachments { get; set; }
    }

    public class Attachment
    {
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("fallback")]
        public string Fallback { get; set; }

        [JsonProperty("thumb_url")]
        public Uri ThumbUrl { get; set; }

        [JsonProperty("thumb_width")]
        public long ThumbWidth { get; set; }

        [JsonProperty("thumb_height")]
        public long ThumbHeight { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
    public partial class ResponseMetadata
    {
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}