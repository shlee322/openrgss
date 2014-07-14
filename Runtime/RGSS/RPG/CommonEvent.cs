using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class CommonEvent : ISerializable
    {
        public int id;
        public string name;
        public int trigger;
        public int switch_id;
        public RubyArray list = new RubyArray();

        public CommonEvent()
        {
        }

        public CommonEvent(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.trigger = (int)info.GetValue("@trigger", typeof(int));
            this.switch_id = (int)info.GetValue("@switch_id", typeof(int));

            this.list = (RubyArray)info.GetValue("@list", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
