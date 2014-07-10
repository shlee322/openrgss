using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Armor
    {
        public int id;
        public string name;
        public string icon_name;
        public string description;
        public int kind;
        public int auto_state_id;
        public int price;
        public int pdef;
        public int mdef;
        public int eva;
        public int str_plus;
        public int dex_plus;
        public int agi_plus;
        public int int_plus;
        public IList<object> guard_element_set;
        public IList<object> guard_state_set;
    }
}
