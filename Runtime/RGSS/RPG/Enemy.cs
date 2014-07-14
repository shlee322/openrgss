using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Enemy : ISerializable
    {
        [Serializable]
        public class Action : ISerializable
        {
            public int kind;
            public int basic;
            public int skill_id;
            public int condition_turn_a;
            public int condition_turn_b;
            public int condition_hp;
            public int condition_level;
            public int condition_switch_id;
            public int rating;

            public Action(SerializationInfo info, StreamingContext context)
            {
                this.kind = (int)info.GetValue("@kind", typeof(int));
                this.basic = (int)info.GetValue("@basic", typeof(int));
                this.skill_id = (int)info.GetValue("@skill_id", typeof(int));
                this.condition_turn_a = (int)info.GetValue("@condition_turn_a", typeof(int));
                this.condition_turn_b = (int)info.GetValue("@condition_turn_b", typeof(int));
                this.condition_hp = (int)info.GetValue("@condition_hp", typeof(int));
                this.condition_level = (int)info.GetValue("@condition_level", typeof(int));
                this.condition_switch_id = (int)info.GetValue("@condition_switch_id", typeof(int));
                this.rating = (int)info.GetValue("@rating", typeof(int));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int id;
        public string name;
        public string battler_name;
        public int battler_hue;
        public int maxhp;
        public int maxsp;
        public int str;
        public int dex;
        public int agi;
        public int Int;
        public int atk;
        public int pdef;
        public int mdef;
        public int eva;
        public int animation1_id;
        public int animation2_id;
        public Table element_ranks;
        public Table state_ranks;
        public RubyArray actions = new RubyArray();
        public int exp;
        public int gold;
        public int item_id;
        public int weapon_id;
        public int armor_id;
        public int treasure_prob;

        public Enemy()
        {
        }

        public Enemy(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.battler_name = ((MutableString)info.GetValue("@battler_name", typeof(MutableString))).ConvertToString();
            this.battler_hue = (int)info.GetValue("@battler_hue", typeof(int));
            this.maxhp = (int)info.GetValue("@maxhp", typeof(int));
            this.maxsp = (int)info.GetValue("@maxsp", typeof(int));
            this.str = (int)info.GetValue("@str", typeof(int));
            this.dex = (int)info.GetValue("@dex", typeof(int));
            this.agi = (int)info.GetValue("@agi", typeof(int));
            this.Int = (int)info.GetValue("@int", typeof(int));
            this.atk = (int)info.GetValue("@atk", typeof(int));
            this.pdef = (int)info.GetValue("@pdef", typeof(int));
            this.mdef = (int)info.GetValue("@mdef", typeof(int));
            this.eva = (int)info.GetValue("@eva", typeof(int));
            this.animation1_id = (int)info.GetValue("@animation1_id", typeof(int));
            this.animation2_id = (int)info.GetValue("@animation2_id", typeof(int));
            this.element_ranks = (Table)info.GetValue("@element_ranks", typeof(Table));
            this.state_ranks = (Table)info.GetValue("@state_ranks", typeof(Table));
            this.actions = (RubyArray)info.GetValue("@actions", typeof(RubyArray));
            this.exp = (int)info.GetValue("@exp", typeof(int));
            this.gold = (int)info.GetValue("@gold", typeof(int));
            this.item_id = (int)info.GetValue("@item_id", typeof(int));
            this.weapon_id = (int)info.GetValue("@weapon_id", typeof(int));
            this.armor_id = (int)info.GetValue("@armor_id", typeof(int));
            this.treasure_prob = (int)info.GetValue("@treasure_prob", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
