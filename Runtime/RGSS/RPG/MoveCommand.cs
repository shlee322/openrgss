using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class MoveCommand : ISerializable
    {
        public int code;
        public RubyArray parameters = new RubyArray();

        public MoveCommand()
        {
        }

        public MoveCommand(SerializationInfo info, StreamingContext context)
        {
            this.code = (int)info.GetValue("@code", typeof(int));
            this.parameters = (RubyArray)info.GetValue("@parameters", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
