using System.Collections.Generic;

namespace BPSSlack.JsonSlackObjects
{/// <summary>
/// Dies ist der Container für die SlackUser, die abgerufen werden können
/// </summary>
    public class ContainerSlackUserList
    {
        public bool ok { get; }
        public string error { get; set; }
        public List<Member> members { get; set; }
    }

    public class Member
    {
        public string id { get; set; }
        public string name { get; set; }
        public string real_name { get; set; }
        public Profile profile { get; set; }
    }

    public class Profile
    {
        public string email { get; set; }
    }
}