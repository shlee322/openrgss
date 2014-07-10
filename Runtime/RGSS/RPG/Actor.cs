namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Actor
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
    }
}
