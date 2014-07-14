using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Animation : ISerializable
    {
        public class Frame : ISerializable
        {
            public int cell_max;
            public Table cell_data;

            public Frame()
            {
            }

            public Frame(SerializationInfo info, StreamingContext context)
            {
                this.cell_max = (int)info.GetValue("@cell_max", typeof(int));
                this.cell_data = (Table)info.GetValue("@cell_data", typeof(Table));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public class Timing : ISerializable
        {
            public int frame;
            public AudioFile se;
            public int flash_scope;
            public Color flash_color;
            public int flash_duration;
            public int condition;

            public Timing()
            {
            }

            public Timing(SerializationInfo info, StreamingContext context)
            {
                this.frame = (int)info.GetValue("@frame", typeof(int));
                this.se = (AudioFile)info.GetValue("@se", typeof(AudioFile));
                this.flash_scope = (int)info.GetValue("@flash_scope", typeof(int));
                this.flash_color = (Color)info.GetValue("@flash_color", typeof(Color));
                this.flash_duration = (int)info.GetValue("@flash_duration", typeof(int));
                this.condition = (int)info.GetValue("@condition", typeof(int));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int id;
        public string name;
        public string animation_name;
        public int animation_hue;
        public int position;
        public int frame_max;
        public RubyArray frames = new RubyArray();
        public RubyArray timings = new RubyArray();

        public Animation()
        {
        }

        public Animation(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.animation_name = ((MutableString)info.GetValue("@animation_name", typeof(MutableString))).ConvertToString();
            this.animation_hue = (int)info.GetValue("@animation_hue", typeof(int));
            this.position = (int)info.GetValue("@position", typeof(int));
            this.frame_max = (int)info.GetValue("@frame_max", typeof(int));

            this.frames = ((RubyArray)info.GetValue("@frames", typeof(RubyArray)));
            this.timings = ((RubyArray)info.GetValue("@timings", typeof(RubyArray)));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
