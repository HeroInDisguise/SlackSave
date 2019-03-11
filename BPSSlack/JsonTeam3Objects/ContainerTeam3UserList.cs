using System.Collections.Generic;

namespace BPSSlack.JsonTeam3Objects
{/// <summary>
/// Dies ist der Container für die SlackUser, die abgerufen werden können
/// </summary>
    public class ContainerTeam3UserList
    {       
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