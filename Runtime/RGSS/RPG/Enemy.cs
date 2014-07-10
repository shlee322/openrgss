using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Enemy
    {
        public class Action
        {
            public int kind;
            public int basic;
            public int skill_id;
            public int condition_turn_a;
            public int condition_turn_b;
            public int condition_hp;
            public int condition_level;
            public int condition_switch_id;
            public int rating;
        }

        public int id;
        public string name;
        public string battler_name;
        public int battler_hue;
        public int maxhp;
        public int maxsp;
        public int str;
        public int dex;
        public int agi;
        public int _int;
        public int atk;
        public int pdef;
        public int mdef;
        public int eva;
        public int animation1_id;
        public int animation2_id;
        public Table element_ranks;
        public Table state_ranks;
        public IList<Action> actions;
        public int exp;
        public int gold;
        public int item_id;
        public int weapon_id;
        public int armor_id;
        public int treasure_prob;
    }
}
