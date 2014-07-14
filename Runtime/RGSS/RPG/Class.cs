using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Class : ISerializable
    {
        [Serializable]
        public class Learning : ISerializable
        {
            public int level;
            public int skill_id;

            public Learning()
            {
            }

            public Learning(SerializationInfo info, StreamingContext context)
                : this()
            {
                this.level = (int)info.GetValue("@level", typeof(int));
                this.skill_id = (int)info.GetValue("@skill_id", typeof(int));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int id;
        public string name;
        public int position;
        public RubyArray weapon_set = new RubyArray();
        public RubyArray armor_set = new RubyArray();
        public Table element_ranks;
        public Table state_ranks;
        public RubyArray learnings = new RubyArray();

        public Class()
        {
        }

        public Class(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.position = (int)info.GetValue("@position", typeof(int));
            this.weapon_set.Clear();
            this.weapon_set = (RubyArray)info.GetValue("@weapon_set", typeof(RubyArray));
            this.armor_set.Clear();
            this.armor_set = (RubyArray)info.GetValue("@armor_set", typeof(RubyArray));
            this.element_ranks = (Table)info.GetValue("@element_ranks", typeof(Table));
            this.state_ranks = (Table)info.GetValue("@state_ranks", typeof(Table));
            this.learnings.Clear();
            this.learnings = (RubyArray)info.GetValue("@learnings", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
