using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Skill : ISerializable
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
        public RubyArray element_set = new RubyArray();
        public RubyArray plus_state_set = new RubyArray();
        public RubyArray minus_state_set = new RubyArray();

        public Skill()
        {
        }

        public Skill(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.icon_name = ((MutableString)info.GetValue("@icon_name", typeof(MutableString))).ConvertToString();
            this.description = ((MutableString)info.GetValue("@description", typeof(MutableString))).ConvertToString();
            this.scope = (int)info.GetValue("@scope", typeof(int));
            this.occasion = (int)info.GetValue("@occasion", typeof(int));
            this.animation1_id = (int)info.GetValue("@animation1_id", typeof(int));
            this.animation2_id = (int)info.GetValue("@animation2_id", typeof(int));
            this.menu_se = (AudioFile)info.GetValue("@menu_se", typeof(AudioFile));
            this.common_event_id = (int)info.GetValue("@common_event_id", typeof(int));
            this.sp_cost = (int)info.GetValue("@sp_cost", typeof(int));
            this.power = (int)info.GetValue("@power", typeof(int));
            this.atk_f = (int)info.GetValue("@atk_f", typeof(int));
            this.eva_f = (int)info.GetValue("@eva_f", typeof(int));
            this.str_f = (int)info.GetValue("@str_f", typeof(int));
            this.dex_f = (int)info.GetValue("@dex_f", typeof(int));
            this.agi_f = (int)info.GetValue("@agi_f", typeof(int));
            this.int_f = (int)info.GetValue("@int_f", typeof(int));
            this.hit = (int)info.GetValue("@hit", typeof(int));
            this.pdef_f = (int)info.GetValue("@pdef_f", typeof(int));
            this.mdef_f = (int)info.GetValue("@mdef_f", typeof(int));
            this.variance = (int)info.GetValue("@variance", typeof(int));
            this.element_set = ((RubyArray)info.GetValue("@element_set", typeof(RubyArray)));
            this.plus_state_set = ((RubyArray)info.GetValue("@plus_state_set", typeof(RubyArray)));
            this.minus_state_set = ((RubyArray)info.GetValue("@minus_state_set", typeof(RubyArray)));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
