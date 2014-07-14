using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Troop : ISerializable
    {
        [Serializable]
        public class Member : ISerializable
        {
            public int enemy_id;
            public int x;
            public int y;
            public bool hidden;
            public bool immortal;

            public Member()
            {
            }

            public Member(SerializationInfo info, StreamingContext context)
            {
                this.enemy_id = (int)info.GetValue("@enemy_id", typeof(int));
                this.x = (int)info.GetValue("@x", typeof(int));
                this.y = (int)info.GetValue("@y", typeof(int));
                this.hidden = (bool)info.GetValue("@hidden", typeof(bool));
                this.immortal = (bool)info.GetValue("@immortal", typeof(bool));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        [Serializable]
        public class Page : ISerializable
        {
            [Serializable]
            public class Condition : ISerializable
            {
                public bool turn_valid;
                public bool enemy_valid;
                public bool actor_valid;
                public bool switch_valid;
                public int turn_a;
                public int turn_b;
                public int enemy_index;
                public int enemy_hp;
                public int actor_id;
                public int actor_hp;
                public int switch_id;

                public Condition()
                {
                }

                public Condition(SerializationInfo info, StreamingContext context)
                {
                    this.turn_valid = (bool)info.GetValue("@turn_valid", typeof(bool));
                    this.enemy_valid = (bool)info.GetValue("@enemy_valid", typeof(bool));
                    this.actor_valid = (bool)info.GetValue("@actor_valid", typeof(bool));
                    this.switch_valid = (bool)info.GetValue("@switch_valid", typeof(bool));
                    this.turn_a = (int)info.GetValue("@turn_a", typeof(int));
                    this.turn_b = (int)info.GetValue("@turn_b", typeof(int));
                    this.enemy_index = (int)info.GetValue("@enemy_index", typeof(int));
                    this.enemy_hp = (int)info.GetValue("@enemy_hp", typeof(int));
                    this.actor_id = (int)info.GetValue("@actor_id", typeof(int));
                    this.actor_hp = (int)info.GetValue("@actor_hp", typeof(int));
                    this.switch_id = (int)info.GetValue("@switch_id", typeof(int));
                }

                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                }
            }

            public Condition condition;
            public int span;
            public RubyArray list = new RubyArray();

            public Page()
            {
            }

            public Page(SerializationInfo info, StreamingContext context)
            {
                this.condition = (Condition)info.GetValue("@condition", typeof(Condition));
                this.span = (int)info.GetValue("@span", typeof(int));
                this.list = (RubyArray)info.GetValue("@list", typeof(RubyArray));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int id;
        public string name;
        public RubyArray members = new RubyArray();
        public RubyArray pages = new RubyArray();

        public Troop()
        {
        }

        public Troop(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.members = (RubyArray)info.GetValue("@members", typeof(RubyArray));
            this.pages = (RubyArray)info.GetValue("@pages", typeof(RubyArray));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
