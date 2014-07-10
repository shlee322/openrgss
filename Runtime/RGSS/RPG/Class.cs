using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Class
    {
        public class Learning
        {
            public int level;
            public int skill_id;
        }

        public int id;
        public string name;
        public int position;
        public IList<object> weapon_set;
        public IList<object> armor_set;
        public Table element_ranks;
        public Table state_ranks;
        public IList<object> learnings;
    }
}
