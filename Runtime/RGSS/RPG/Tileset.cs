namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Tileset
    {
        public int id;
        public string name;
        public string tileset_name;
        public string[] autotile_names;
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
    }
}
