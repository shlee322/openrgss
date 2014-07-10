using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Animation
    {
        public class Frame
        {
            public int cell_max;
            public Table cell_data;
        }

        public class Timing
        {
            public int frame;
            public AudioFile se;
            public int flash_scope;
            public Color flash_color;
            public int flash_duration;
            public int condition;
        }

        public int id;
        public string name;
        public string animation_name;
        public int animation_hue;
        public int position;
        public int frame_max;
        public IList<Frame> frames;
        public IList<Timing> timings;
    }
}
