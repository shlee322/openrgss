using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class MoveRoute : ISerializable
    {
        public bool repeat;
        public bool skippable;
        public RubyArray list = new RubyArray();

        public MoveRoute()
        {
        }

        public MoveRoute(SerializationInfo info, StreamingContext context)
        {
            this.repeat = (bool)info.GetValue("@repeat", typeof(bool));
            this.skippable = (bool)info.GetValue("@skippable", typeof(bool));
            this.list = (RubyArray)info.GetValue("@list", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
