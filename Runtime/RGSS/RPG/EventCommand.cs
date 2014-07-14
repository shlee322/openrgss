using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class EventCommand : ISerializable
    {
        public int code;
        public int indent;
        public RubyArray parameters = new RubyArray();

        public EventCommand()
        {
        }

        public EventCommand(SerializationInfo info, StreamingContext context)
        {
            this.code = (int)info.GetValue("@code", typeof(int));
            this.indent = (int)info.GetValue("@indent", typeof(int));
            this.parameters = (RubyArray)info.GetValue("@parameters", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
