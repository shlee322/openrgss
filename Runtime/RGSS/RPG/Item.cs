using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Item
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
        public int price;
        public bool consumable;
        public int parameter_type;
        public int parameter_points;
        public int recover_hp_rate;
        public int recover_hp;
        public int recover_sp_rate;
        public int recover_sp;
        public int hit;
        public int pdef_f;
        public int mdef_f;
        public int variance;
        public IList<object> element_set;
        public IList<object> plus_state_set;
        public IList<object> minus_state_set;
    }
}
