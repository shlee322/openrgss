using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class System
    {
        public class Words
        {
            public string gold;
            public string hp;
            public string sp;
            public string str;
            public string dex;
            public string agi;
            public string _int;
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
        }

        public class TestBattler
        {
            public int actor_id;
            public int level;
            public int weapon_id;
            public int armor1_id;
            public int armor2_id;
            public int armor3_id;
            public int armor4_id;
        }

        public int magic_number;
        public IList<object> party_members;
        public IList<object> elements;
        public IList<object> switches;
        public IList<object> variables;
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
        public IList<object> test_battlers;
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
            magic_number = 0;
            //party_members = [1];
            //elements = [nil, ""];
            //switches = [nil, ""];
            //variables = [nil, ""];
            windowskin_name = "";
            title_name = "";
            gameover_name = "";
            battle_transition = "";
            title_bgm = new AudioFile();
            battle_bgm = new AudioFile();
            battle_end_me = new AudioFile();
            gameover_me = new AudioFile();
            cursor_se = new AudioFile("", 80);
            decision_se = new AudioFile("", 80);
            cancel_se = new AudioFile("", 80);
            buzzer_se = new AudioFile("", 80);
            equip_se = new AudioFile("", 80);
            shop_se = new AudioFile("", 80);
            save_se = new AudioFile("", 80);
            load_se = new AudioFile("", 80);
            battle_start_se = new AudioFile("", 80);
            escape_se = new AudioFile("", 80);
            actor_collapse_se = new AudioFile("", 80);
            enemy_collapse_se = new AudioFile("", 80);
            words = new Words();
            //test_battlers = [];
            test_troop_id = 1;
            start_map_id = 1;
            start_x = 0;
            start_y = 0;
            battleback_name = "";
            battler_name = "";
            battler_hue = 0;
            edit_map_id = 1;
        }
    }
}
