using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Troop
    {
        public class Member
        {
            public int enemy_id;
            public int x;
            public int y;
            public bool hidden;
            public bool immortal;
        }

        public class Page
        {
            public class Condition
            {
                public bool turn_valid;
                public bool enemy_valid;
                public bool actor_valid;
                public bool switch_valid;
                public int turn_a;
                public int turn_b;
                public int enemy_index;
                public int enemy_hp;
                public int actor_id;
                public int actor_hp;
                public int switch_id;
            }

            public Condition condition;
            public int span;
            public IList<EventCommand> list;
        }

        public int id;
        public string name;
        public IList<Member> members;
        public IList<Page> pages;
    }
}
