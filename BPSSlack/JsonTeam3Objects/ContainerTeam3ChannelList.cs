using System.Collections.Generic;

namespace BPSSlack.JsonTeam3Objects
{
    public class ContainerTeam3ChannelList
    {
        public List<Channel> channels { get; set; }
    }

    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}