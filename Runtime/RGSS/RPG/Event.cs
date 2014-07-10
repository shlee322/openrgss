using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Event
    {
        public class Page
        {
            public class Condition
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
            }

            public class Graphic
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
            public IList<EventCommand> list;

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
        }

        public int id;
        public string name;
        public int x;
        public int y;
        public IList<Page> pages;

        public Event(int x, int y)
        {
            this.id = 0;
            this.name = "";
            this.x = x;
            this.y = y;
            //@pages = [RPG::Event::Page.new]
        }

    }
}
