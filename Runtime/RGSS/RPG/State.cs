using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class State
    {
        public int id;
        public string name;
        public int animation_id;
        public int restriction;
        public bool nonresistance;
        public bool zero_hp;
        public bool cant_get_exp;
        public bool cant_evade;
        public bool slip_damage;
        public int rating;
        public int hit_rate;
        public int maxhp_rate;
        public int maxsp_rate;
        public int str_rate;
        public int dex_rate;
        public int agi_rate;
        public int int_rate;
        public int atk_rate;
        public int pdef_rate;
        public int mdef_rate;
        public int eva;
        public bool battle_only;
        public int hold_turn;
        public int auto_release_prob;
        public int shock_release_prob;
        public IList<object> guard_element_set;
        public IList<object> plus_state_set;
        public IList<object> minus_state_set;
    }
}
