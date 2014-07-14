using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Event : ISerializable
    {
        [Serializable]
        public class Page : ISerializable
        {
            [Serializable]
            public class Condition : ISerializable
            {
                public bool switch1_valid;
                public bool switch2_valid;
                public bool variable_valid;
                public bool self_switch_valid;
                public int switch1_id;
                public int switch2_id;
                public int variable_id;
                public int variable_value;
                public string self_switch_ch;

                public Condition()
                {
                    this.switch1_valid = false;
                    this.switch2_valid = false;
                    this.variable_valid = false;
                    this.self_switch_valid = false;
                    this.switch1_id = 1;
                    this.switch2_id = 1;
                    this.variable_id = 1;
                    this.variable_value = 0;
                    this.self_switch_ch = "A";
                }

                public Condition(SerializationInfo info, StreamingContext context)
                {
                    this.switch1_valid = (bool)info.GetValue("@switch1_valid", typeof(bool));
                    this.switch2_valid = (bool)info.GetValue("@switch2_valid", typeof(bool));
                    this.variable_valid = (bool)info.GetValue("@variable_valid", typeof(bool));
                    this.self_switch_valid = (bool)info.GetValue("@self_switch_valid", typeof(bool));
                    this.switch1_id = (int)info.GetValue("@switch1_id", typeof(int));
                    this.switch2_id = (int)info.GetValue("@switch2_id", typeof(int));
                    this.variable_id = (int)info.GetValue("@variable_id", typeof(int));
                    this.variable_value = (int)info.GetValue("@variable_value", typeof(int));
                    this.self_switch_ch = ((MutableString)info.GetValue("@self_switch_ch", typeof(MutableString))).ConvertToString();
                }

                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                }
            }

            [Serializable]
            public class Graphic : ISerializable
            {
                public int tile_id;
                public string character_name;
                public int character_hue;
                public int direction;
                public int pattern;
                public int opacity;
                public int blend_type;

                public Graphic()
                {
                    this.tile_id = 0;
                    this.character_name = "";
                    this.character_hue = 0;
                    this.direction = 2;
                    this.pattern = 0;
                    this.opacity = 255;
                    this.blend_type = 0;
                }

                public Graphic(SerializationInfo info, StreamingContext context)
                {
                    this.tile_id = (int)info.GetValue("@tile_id", typeof(int));
                    this.character_name = ((MutableString)info.GetValue("@character_name", typeof(MutableString))).ConvertToString();
                    this.character_hue = (int)info.GetValue("@character_hue", typeof(int));
                    this.direction = (int)info.GetValue("@direction", typeof(int));
                    this.pattern = (int)info.GetValue("@pattern", typeof(int));
                    this.opacity = (int)info.GetValue("@opacity", typeof(int));
                    this.blend_type = (int)info.GetValue("@blend_type", typeof(int));
                }

                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                }
            }

            public Condition condition;
            public Graphic graphic;
            public int move_type;
            public int move_speed;
            public int move_frequency;
            public MoveRoute move_route;
            public bool walk_anime;
            public bool step_anime;
            public bool direction_fix;
            public bool through;
            public bool always_on_top;
            public int trigger;
            public RubyArray list = new RubyArray();

            public Page()
            {
                this.condition = new Condition();
                this.graphic = new Graphic();
                this.move_type = 0;
                this.move_speed = 3;
                this.move_frequency = 3;
                this.move_route = new MoveRoute();
                this.walk_anime = true;
                this.step_anime = false;
                this.direction_fix = false;
                this.through = false;
                this.always_on_top = false;
                this.trigger = 0;
                //this.list = EventCommand
            }

            public Page(SerializationInfo info, StreamingContext context)
            {
                this.condition = (Condition)info.GetValue("@condition", typeof(Condition));
                this.graphic = (Graphic)info.GetValue("@graphic", typeof(Graphic));
                this.move_type = (int)info.GetValue("@move_type", typeof(int));
                this.move_speed = (int)info.GetValue("@move_speed", typeof(int));
                this.move_frequency = (int)info.GetValue("@move_frequency", typeof(int));
                this.move_route = (MoveRoute)info.GetValue("@move_route", typeof(MoveRoute));
                this.walk_anime = (bool)info.GetValue("@walk_anime", typeof(bool));
                this.step_anime = (bool)info.GetValue("@step_anime", typeof(bool));
                this.direction_fix = (bool)info.GetValue("@direction_fix", typeof(bool));
                this.through = (bool)info.GetValue("@through", typeof(bool));
                this.always_on_top = (bool)info.GetValue("@always_on_top", typeof(bool));
                this.trigger = (int)info.GetValue("@trigger", typeof(int));
                this.list = (RubyArray)info.GetValue("@list", typeof(RubyArray));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int id;
        public string name;
        public int x;
        public int y;
        public RubyArray pages = new RubyArray();

        public Event()
        {
        }

        public Event(int x, int y)
        {
            this.id = 0;
            this.name = "";
            this.x = x;
            this.y = y;
            this.pages.Add(new Page());
        }

        public Event(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.x = (int)info.GetValue("@x", typeof(int));
            this.y = (int)info.GetValue("@y", typeof(int));
            this.pages = (RubyArray)info.GetValue("@pages", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
