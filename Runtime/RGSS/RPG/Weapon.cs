using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Weapon
    {
        public int id;
        public string name;
        public string icon_name;
        public string description;
        public int animation1_id;
        public int animation2_id;
        public int price;
        public int atk;
        public int pdef;
        public int mdef;
        public int str_plus;
        public int dex_plus;
        public int agi_plus;
        public int int_plus;
        public IList<object> element_set;
        public IList<object> plus_state_set;
        public IList<object> minus_state_set;
    }
}
