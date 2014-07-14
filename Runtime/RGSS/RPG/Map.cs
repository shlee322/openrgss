using IronRuby.Builtins;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Map : ISerializable
    {
        public int tileset_id;
        public int width;
        public int height;
        public bool autoplay_bgm;
        public AudioFile bgm;
        public bool autoplay_bgs;
        public AudioFile bgs;
        public RubyArray encounter_list = new RubyArray();
        public int encounter_step;
        public Table data;
        public Hash events = new Hash(new Dictionary<object, object>());

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

        public Map(SerializationInfo info, StreamingContext context)
        {
            this.tileset_id = (int)info.GetValue("@tileset_id", typeof(int));
            this.width = (int)info.GetValue("@width", typeof(int));
            this.height = (int)info.GetValue("@height", typeof(int));
            this.autoplay_bgm = (bool)info.GetValue("@autoplay_bgm", typeof(bool));
            this.bgm = (AudioFile)info.GetValue("@bgm", typeof(AudioFile));
            this.autoplay_bgs = (bool)info.GetValue("@autoplay_bgs", typeof(bool));
            this.bgs = (AudioFile)info.GetValue("@bgs", typeof(AudioFile));
            this.encounter_list = (RubyArray)info.GetValue("@encounter_list", typeof(RubyArray));
            this.encounter_step = (int)info.GetValue("@encounter_step", typeof(int));
            this.data = (Table)info.GetValue("@data", typeof(Table));
            this.events = (Hash)info.GetValue("@events", typeof(Hash));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
