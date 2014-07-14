using IronRuby.Builtins;
using System;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Actor : ISerializable
    {
        public int id;
        public string name;
        public int class_id;
        public int initial_level;
        public int final_level;
        public int exp_basis;
        public int exp_inflation;
        public string character_name;
        public int character_hue;
        public string battler_name;
        public int battler_hue;
        public Table parameters;
        public int weapon_id;
        public int armor1_id;
        public int armor2_id;
        public int armor3_id;
        public int armor4_id;
        public bool weapon_fix;
        public bool armor1_fix;
        public bool armor2_fix;
        public bool armor3_fix;
        public bool armor4_fix;

        public Actor()
        {
        }

        public Actor(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.class_id = (int)info.GetValue("@class_id", typeof(int));
            this.initial_level = (int)info.GetValue("@initial_level", typeof(int));
            this.final_level = (int)info.GetValue("@final_level", typeof(int));
            this.exp_basis = (int)info.GetValue("@exp_basis", typeof(int));
            this.exp_inflation = (int)info.GetValue("@exp_inflation", typeof(int));
            this.character_name = ((MutableString)info.GetValue("@character_name", typeof(MutableString))).ConvertToString();
            this.character_hue = (int)info.GetValue("@character_hue", typeof(int));
            this.battler_name = ((MutableString)info.GetValue("@battler_name", typeof(MutableString))).ConvertToString();
            this.battler_hue = (int)info.GetValue("@battler_hue", typeof(int));
            this.parameters = (Table)info.GetValue("@parameters", typeof(Table));
            this.weapon_id = (int)info.GetValue("@weapon_id", typeof(int));
            this.armor1_id = (int)info.GetValue("@armor1_id", typeof(int));
            this.armor2_id = (int)info.GetValue("@armor2_id", typeof(int));
            this.armor3_id = (int)info.GetValue("@armor3_id", typeof(int));
            this.armor4_id = (int)info.GetValue("@armor4_id", typeof(int));
            this.weapon_fix = (bool)info.GetValue("@weapon_fix", typeof(bool));
            this.armor1_fix = (bool)info.GetValue("@armor1_fix", typeof(bool));
            this.armor2_fix = (bool)info.GetValue("@armor2_fix", typeof(bool));
            this.armor3_fix = (bool)info.GetValue("@armor3_fix", typeof(bool));
            this.armor4_fix = (bool)info.GetValue("@armor4_fix", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
