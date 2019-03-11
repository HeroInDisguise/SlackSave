using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
{/// <summary>
/// Dies ist der Container für SlackChannels die abgerufen werden können
/// </summary>
    public class ContainerSlackChannelList
    {
        public bool ok { get; }
        public string error { get; set; }
        public List<Channels> channels { get; set; }
    }
     
    public class Channels
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}