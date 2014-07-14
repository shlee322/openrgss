using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class State : ISerializable
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
        public RubyArray guard_element_set = new RubyArray();
        public RubyArray plus_state_set = new RubyArray();
        public RubyArray minus_state_set = new RubyArray();

        public State()
        {
        }

        public State(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.animation_id = (int)info.GetValue("@animation_id", typeof(int));
            this.restriction = (int)info.GetValue("@restriction", typeof(int));
            this.nonresistance = (bool)info.GetValue("@nonresistance", typeof(bool));
            this.zero_hp = (bool)info.GetValue("@zero_hp", typeof(bool));
            this.cant_get_exp = (bool)info.GetValue("@cant_get_exp", typeof(bool));
            this.cant_evade = (bool)info.GetValue("@cant_evade", typeof(bool));
            this.slip_damage = (bool)info.GetValue("@slip_damage", typeof(bool));
            this.rating = (int)info.GetValue("@rating", typeof(int));
            this.hit_rate = (int)info.GetValue("@hit_rate", typeof(int));
            this.maxhp_rate = (int)info.GetValue("@maxhp_rate", typeof(int));
            this.maxsp_rate = (int)info.GetValue("@maxsp_rate", typeof(int));
            this.str_rate = (int)info.GetValue("@str_rate", typeof(int));
            this.dex_rate = (int)info.GetValue("@dex_rate", typeof(int));
            this.agi_rate = (int)info.GetValue("@agi_rate", typeof(int));
            this.int_rate = (int)info.GetValue("@int_rate", typeof(int));
            this.atk_rate = (int)info.GetValue("@atk_rate", typeof(int));
            this.pdef_rate = (int)info.GetValue("@pdef_rate", typeof(int));
            this.mdef_rate = (int)info.GetValue("@mdef_rate", typeof(int));
            this.eva = (int)info.GetValue("@eva", typeof(int));
            this.battle_only = (bool)info.GetValue("@battle_only", typeof(bool));
            this.hold_turn = (int)info.GetValue("@hold_turn", typeof(int));
            this.auto_release_prob = (int)info.GetValue("@auto_release_prob", typeof(int));
            this.shock_release_prob = (int)info.GetValue("@shock_release_prob", typeof(int));
            this.guard_element_set = ((RubyArray)info.GetValue("@guard_element_set", typeof(RubyArray)));
            this.plus_state_set = ((RubyArray)info.GetValue("@plus_state_set", typeof(RubyArray)));
            this.minus_state_set = ((RubyArray)info.GetValue("@minus_state_set", typeof(RubyArray)));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
