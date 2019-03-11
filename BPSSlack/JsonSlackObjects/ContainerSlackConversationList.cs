using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
{/// <summary>
/// Dies ist der Container für SlackChannels die abgerufen werden können
/// </summary>
    public class ContainerSlackConversationList
    {
        public bool ok { get; }
        public string error { get; set; }
        public List<Im> Ims { get; set; }
    }
     
    public class Im
    {
        public string id { get; set; }
        public string user { get; set; }
    }
}