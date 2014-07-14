using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Armor : ISerializable
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
        public RubyArray guard_element_set = new RubyArray();
        public RubyArray guard_state_set = new RubyArray();

        public Armor()
        {
        }

        public Armor(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.icon_name = ((MutableString)info.GetValue("@icon_name", typeof(MutableString))).ConvertToString();
            this.description = ((MutableString)info.GetValue("@description", typeof(MutableString))).ConvertToString();
            this.kind = (int)info.GetValue("@kind", typeof(int));
            this.auto_state_id = (int)info.GetValue("@auto_state_id", typeof(int));
            this.price = (int)info.GetValue("@price", typeof(int));
            this.pdef = (int)info.GetValue("@pdef", typeof(int));
            this.mdef = (int)info.GetValue("@mdef", typeof(int));
            this.eva = (int)info.GetValue("@eva", typeof(int));
            this.str_plus = (int)info.GetValue("@str_plus", typeof(int));
            this.dex_plus = (int)info.GetValue("@dex_plus", typeof(int));
            this.agi_plus = (int)info.GetValue("@agi_plus", typeof(int));
            this.int_plus = (int)info.GetValue("@int_plus", typeof(int));
            this.guard_element_set = ((RubyArray)info.GetValue("@guard_element_set", typeof(RubyArray)));
            this.guard_state_set = ((RubyArray)info.GetValue("@guard_state_set", typeof(RubyArray)));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
