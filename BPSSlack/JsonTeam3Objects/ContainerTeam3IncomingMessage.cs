using System.Collections.Generic;

namespace BPSSlack.JsonTeam3Objects
{
    class ContainerTeam3IncomingMessage
    {        
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public string type { get; set; }
        public string text { get; set; }
        public string user { get; set; }
        public string ts { get; set; }
        public List<Attachments> attachments { get; set; }
    }

    public class Attachments
    {
        public string text { get; set; }
        public string thumb_url { get; set; }
        public string thumb_width { get; set; }
        public string thumb_height { get; set; }
        public string id { get; set; }
    }
}