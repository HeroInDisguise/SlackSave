using System.Collections.Generic;

namespace BPSSlack.JsonTeam3Objects
{/// <summary>
/// Dies ist der Container für SlackChannels die abgerufen werden können
/// </summary>
    public class ContainerTeam3ConversationList
    {        
        public List<Im> Ims { get; set; }
    }
     
    public class Im
    {
        public string id { get; set; }
        public string user { get; set; }
    }
}