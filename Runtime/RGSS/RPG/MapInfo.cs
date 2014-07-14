using IronRuby.Builtins;
using System;
using System.Runtime.Serialization;
namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class MapInfo : ISerializable
    {
        public string name="";
        public int parent_id=0;
        public int order=0;
        public bool expanded = false;
        public int scroll_x=0;
        public int scroll_y=0;

        public MapInfo()
        {
        }

        public MapInfo(SerializationInfo info, StreamingContext context)
        {
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.parent_id = (int)info.GetValue("@parent_id", typeof(int));
            this.order = (int)info.GetValue("@order", typeof(int));
            this.expanded = (bool)info.GetValue("@expanded", typeof(bool));
            this.scroll_x = (int)info.GetValue("@scroll_x", typeof(int));
            this.scroll_y = (int)info.GetValue("@scroll_y", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
