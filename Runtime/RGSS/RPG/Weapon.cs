using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Weapon : ISerializable
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
        public RubyArray element_set = new RubyArray();
        public RubyArray plus_state_set = new RubyArray();
        public RubyArray minus_state_set = new RubyArray();

        public Weapon()
        {
        }

        public Weapon(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.icon_name = ((MutableString)info.GetValue("@icon_name", typeof(MutableString))).ConvertToString();
            this.description = ((MutableString)info.GetValue("@description", typeof(MutableString))).ConvertToString();
            this.animation1_id = (int)info.GetValue("@animation1_id", typeof(int));
            this.animation2_id = (int)info.GetValue("@animation2_id", typeof(int));
            this.price = (int)info.GetValue("@price", typeof(int));
            this.atk = (int)info.GetValue("@atk", typeof(int));
            this.pdef = (int)info.GetValue("@pdef", typeof(int));
            this.mdef = (int)info.GetValue("@mdef", typeof(int));
            this.str_plus = (int)info.GetValue("@str_plus", typeof(int));
            this.dex_plus = (int)info.GetValue("@dex_plus", typeof(int));
            this.agi_plus = (int)info.GetValue("@agi_plus", typeof(int));
            this.int_plus = (int)info.GetValue("@int_plus", typeof(int));
            this.element_set = ((RubyArray)info.GetValue("@element_set", typeof(RubyArray)));
            this.plus_state_set = ((RubyArray)info.GetValue("@plus_state_set", typeof(RubyArray)));
            this.minus_state_set = ((RubyArray)info.GetValue("@minus_state_set", typeof(RubyArray)));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
