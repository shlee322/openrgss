using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Skill
    {
        public int id;
        public string name;
        public string icon_name;
        public string description;
        public int scope;
        public int occasion;
        public int animation1_id;
        public int animation2_id;
        public AudioFile menu_se;
        public int common_event_id;
        public int sp_cost;
        public int power;
        public int atk_f;
        public int eva_f;
        public int str_f;
        public int dex_f;
        public int agi_f;
        public int int_f;
        public int hit;
        public int pdef_f;
        public int mdef_f;
        public int variance;
        public IList<object> element_set;
        public IList<object> plus_state_set;
        public IList<object> minus_state_set;
    }
}
