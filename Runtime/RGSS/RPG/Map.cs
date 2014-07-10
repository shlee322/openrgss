using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Map
    {
        public int tileset_id;
        public int width;
        public int height;
        public bool autoplay_bgm;
        public AudioFile bgm;
        public bool autoplay_bgs;
        public AudioFile bgs;
        public int encounter_list;
        public int encounter_step;
        public Table data;
        public IDictionary<string, Event> events;

        public Map()
        {
        }

        public Map(int width, int height)
        {
            this.tileset_id = 1;
            this.width = width;
            this.height = height;
            this.autoplay_bgm = false;
            this.bgm = new AudioFile();
            this.autoplay_bgs = false;
            this.bgs = new AudioFile("", 80);
            //this.encounter_list = []
            this.encounter_step = 30;
            this.data = new Table(width, height, 3);
            //this.events = 
        }
    }
}
