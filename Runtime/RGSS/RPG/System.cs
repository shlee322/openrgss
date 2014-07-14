using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using IronRuby.Builtins;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class System : ISerializable
    {
        [Serializable]
        public class Words : ISerializable
        {
            public string gold;
            public string hp;
            public string sp;
            public string str;
            public string dex;
            public string agi;
            public string Int;
            public string atk;
            public string pdef;
            public string mdef;
            public string weapon;
            public string armor1;
            public string armor2;
            public string armor3;
            public string armor4;
            public string attack;
            public string skill;
            public string guard;
            public string item;
            public string equip;

            public Words()
            {
            }

            public Words(SerializationInfo info, StreamingContext context)
                : this()
            {
                this.gold = ((MutableString)info.GetValue("@gold", typeof(MutableString))).ConvertToString();
                this.hp = ((MutableString)info.GetValue("@hp", typeof(MutableString))).ConvertToString();
                this.sp = ((MutableString)info.GetValue("@sp", typeof(MutableString))).ConvertToString();
                this.str = ((MutableString)info.GetValue("@str", typeof(MutableString))).ConvertToString();
                this.dex = ((MutableString)info.GetValue("@dex", typeof(MutableString))).ConvertToString();
                this.agi = ((MutableString)info.GetValue("@agi", typeof(MutableString))).ConvertToString();
                this.Int = ((MutableString)info.GetValue("@int", typeof(MutableString))).ConvertToString();
                this.atk = ((MutableString)info.GetValue("@atk", typeof(MutableString))).ConvertToString();
                this.pdef = ((MutableString)info.GetValue("@pdef", typeof(MutableString))).ConvertToString();
                this.mdef = ((MutableString)info.GetValue("@mdef", typeof(MutableString))).ConvertToString();
                this.weapon = ((MutableString)info.GetValue("@weapon", typeof(MutableString))).ConvertToString();
                this.armor1 = ((MutableString)info.GetValue("@armor1", typeof(MutableString))).ConvertToString();
                this.armor2 = ((MutableString)info.GetValue("@armor2", typeof(MutableString))).ConvertToString();
                this.armor3 = ((MutableString)info.GetValue("@armor3", typeof(MutableString))).ConvertToString();
                this.armor4 = ((MutableString)info.GetValue("@armor4", typeof(MutableString))).ConvertToString();
                this.attack = ((MutableString)info.GetValue("@attack", typeof(MutableString))).ConvertToString();
                this.skill = ((MutableString)info.GetValue("@skill", typeof(MutableString))).ConvertToString();
                this.guard = ((MutableString)info.GetValue("@guard", typeof(MutableString))).ConvertToString();
                this.item = ((MutableString)info.GetValue("@item", typeof(MutableString))).ConvertToString();
                this.equip = ((MutableString)info.GetValue("@equip", typeof(MutableString))).ConvertToString();
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        [Serializable]
        public class TestBattler : ISerializable
        {
            public int actor_id;
            public int level;
            public int weapon_id;
            public int armor1_id;
            public int armor2_id;
            public int armor3_id;
            public int armor4_id;

            public TestBattler()
            {
            }

            public TestBattler(SerializationInfo info, StreamingContext context)
                : this()
            {
                this.actor_id = (int)info.GetValue("@actor_id", typeof(int));
                this.level = (int)info.GetValue("@level", typeof(int));
                this.weapon_id = (int)info.GetValue("@weapon_id", typeof(int));
                this.armor1_id = (int)info.GetValue("@armor1_id", typeof(int));
                this.armor2_id = (int)info.GetValue("@armor2_id", typeof(int));
                this.armor3_id = (int)info.GetValue("@armor3_id", typeof(int));
                this.armor4_id = (int)info.GetValue("@armor4_id", typeof(int));
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        public int magic_number;
        public RubyArray party_members = new RubyArray();
        public RubyArray elements = new RubyArray();
        public RubyArray switches = new RubyArray();
        public RubyArray variables = new RubyArray();
        public string windowskin_name;
        public string title_name;
        public string gameover_name;
        public string battle_transition;
        public AudioFile title_bgm;
        public AudioFile battle_bgm;
        public AudioFile battle_end_me;
        public AudioFile gameover_me;
        public AudioFile cursor_se;
        public AudioFile decision_se;
        public AudioFile cancel_se;
        public AudioFile buzzer_se;
        public AudioFile equip_se;
        public AudioFile shop_se;
        public AudioFile save_se;
        public AudioFile load_se;
        public AudioFile battle_start_se;
        public AudioFile escape_se;
        public AudioFile actor_collapse_se;
        public AudioFile enemy_collapse_se;
        public Words words;
        public RubyArray test_battlers = new RubyArray();
        public int test_troop_id;
        public int start_map_id;
        public int start_x;
        public int start_y;
        public string battleback_name;
        public string battler_name;
        public int battler_hue;
        public int edit_map_id;
        
        public System()
        {
            this.magic_number = 0;
            this.party_members.Add(1);
            this.elements.Add(null);
            this.elements.Add("");
            this.switches.Add(null);
            this.switches.Add("");
            this.variables.Add(null);
            this.variables.Add("");
            this.windowskin_name = "";
            this.title_name = "";
            this.gameover_name = "";
            this.battle_transition = "";
            this.title_bgm = new AudioFile();
            this.battle_bgm = new AudioFile();
            this.battle_end_me = new AudioFile();
            this.gameover_me = new AudioFile();
            this.cursor_se = new AudioFile("", 80);
            this.decision_se = new AudioFile("", 80);
            this.cancel_se = new AudioFile("", 80);
            this.buzzer_se = new AudioFile("", 80);
            this.equip_se = new AudioFile("", 80);
            this.shop_se = new AudioFile("", 80);
            this.save_se = new AudioFile("", 80);
            this.load_se = new AudioFile("", 80);
            this.battle_start_se = new AudioFile("", 80);
            this.escape_se = new AudioFile("", 80);
            this.actor_collapse_se = new AudioFile("", 80);
            this.enemy_collapse_se = new AudioFile("", 80);
            this.words = new Words();
            this.test_troop_id = 1;
            this.start_map_id = 1;
            this.start_x = 0;
            this.start_y = 0;
            this.battleback_name = "";
            this.battler_name = "";
            this.battler_hue = 0;
            this.edit_map_id = 1;
        }

        public System(SerializationInfo info, StreamingContext context)
        {
            this.magic_number = (int)info.GetValue("@magic_number", typeof(int));
            this.party_members = (RubyArray)info.GetValue("@party_members", typeof(RubyArray));
            this.elements = ((RubyArray)info.GetValue("@elements", typeof(RubyArray)));
            this.switches = ((RubyArray)info.GetValue("@switches", typeof(RubyArray)));
            this.variables = ((RubyArray)info.GetValue("@variables", typeof(RubyArray)));
            this.windowskin_name = ((MutableString)info.GetValue("@windowskin_name", typeof(MutableString))).ConvertToString();
            this.title_name = ((MutableString)info.GetValue("@title_name", typeof(MutableString))).ConvertToString();
            this.gameover_name = ((MutableString)info.GetValue("@gameover_name", typeof(MutableString))).ConvertToString();
            this.battle_transition = ((MutableString)info.GetValue("@battle_transition", typeof(MutableString))).ConvertToString();
            this.title_bgm = (AudioFile)info.GetValue("@title_bgm", typeof(AudioFile));
            this.battle_bgm = (AudioFile)info.GetValue("@battle_bgm", typeof(AudioFile));
            this.battle_end_me = (AudioFile)info.GetValue("@battle_end_me", typeof(AudioFile));
            this.gameover_me = (AudioFile)info.GetValue("@gameover_me", typeof(AudioFile));
            this.cursor_se = (AudioFile)info.GetValue("@cursor_se", typeof(AudioFile));
            this.decision_se = (AudioFile)info.GetValue("@decision_se", typeof(AudioFile));
            this.cancel_se = (AudioFile)info.GetValue("@cancel_se", typeof(AudioFile));
            this.buzzer_se = (AudioFile)info.GetValue("@buzzer_se", typeof(AudioFile));
            this.equip_se = (AudioFile)info.GetValue("@equip_se", typeof(AudioFile));
            this.shop_se = (AudioFile)info.GetValue("@shop_se", typeof(AudioFile));
            this.save_se = (AudioFile)info.GetValue("@save_se", typeof(AudioFile));
            this.load_se = (AudioFile)info.GetValue("@load_se", typeof(AudioFile));
            this.battle_start_se = (AudioFile)info.GetValue("@battle_start_se", typeof(AudioFile));
            this.escape_se = (AudioFile)info.GetValue("@escape_se", typeof(AudioFile));
            this.actor_collapse_se = (AudioFile)info.GetValue("@actor_collapse_se", typeof(AudioFile));
            this.enemy_collapse_se = (AudioFile)info.GetValue("@enemy_collapse_se", typeof(AudioFile));
            this.words = (Words)info.GetValue("@words", typeof(Words));
            this.test_battlers = ((RubyArray)info.GetValue("@test_battlers", typeof(RubyArray)));
            this.test_troop_id = (int)info.GetValue("@test_troop_id", typeof(int));
            this.start_map_id = (int)info.GetValue("@start_map_id", typeof(int));
            this.start_x = (int)info.GetValue("@start_x", typeof(int));
            this.start_y = (int)info.GetValue("@start_y", typeof(int));
            this.battleback_name = ((MutableString)info.GetValue("@battleback_name", typeof(MutableString))).ConvertToString();
            this.battler_name = ((MutableString)info.GetValue("@battler_name", typeof(MutableString))).ConvertToString();
            this.battler_hue = (int)info.GetValue("@battler_hue", typeof(int));
            this.edit_map_id = (int)info.GetValue("@edit_map_id", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
