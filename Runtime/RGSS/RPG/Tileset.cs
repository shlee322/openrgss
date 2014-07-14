using IronRuby.Builtins;
using System;
using System.Runtime.Serialization;
namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class Tileset : ISerializable
    {
        public int id;
        public string name;
        public string tileset_name;
        public string[] autotile_names = new string[7];
        public string panorama_name;
        public int panorama_hue;
        public string fog_name;
        public int fog_hue;
        public int fog_opacity;
        public int fog_blend_type;
        public int fog_zoom;
        public int fog_sx;
        public int fog_sy;
        public string battleback_name;
        public Table passages;
        public Table priorities;
        public Table terrain_tags;

        public Tileset()
        {
        }

        public Tileset(SerializationInfo info, StreamingContext context)
        {
            this.id = (int)info.GetValue("@id", typeof(int));
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.tileset_name = ((MutableString)info.GetValue("@tileset_name", typeof(MutableString))).ConvertToString();
            var autotile_names = ((RubyArray)info.GetValue("@autotile_names", typeof(RubyArray)));
            int autotile_names_i = 0;
            foreach (object obj in autotile_names)
            {
                this.autotile_names[autotile_names_i++] = ((MutableString)obj).ConvertToString();
            }
            this.panorama_name = ((MutableString)info.GetValue("@panorama_name", typeof(MutableString))).ConvertToString();
            this.panorama_hue = (int)info.GetValue("@panorama_hue", typeof(int));
            this.fog_name = ((MutableString)info.GetValue("@fog_name", typeof(MutableString))).ConvertToString();
            this.fog_hue = (int)info.GetValue("@fog_hue", typeof(int));
            this.fog_opacity = (int)info.GetValue("@fog_opacity", typeof(int));
            this.fog_blend_type = (int)info.GetValue("@fog_blend_type", typeof(int));
            this.fog_zoom = (int)info.GetValue("@fog_zoom", typeof(int));
            this.fog_sx = (int)info.GetValue("@fog_sx", typeof(int));
            this.fog_sy = (int)info.GetValue("@fog_sy", typeof(int));
            this.battleback_name = ((MutableString)info.GetValue("@battleback_name", typeof(MutableString))).ConvertToString();
            this.passages = (Table)info.GetValue("@passages", typeof(Table));
            this.priorities = (Table)info.GetValue("@priorities", typeof(Table));
            this.terrain_tags = (Table)info.GetValue("@terrain_tags", typeof(Table));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
