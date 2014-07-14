using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS
{
    public class Font
    {
        public static string default_name = "MS PMincho";
        public static float default_size = 22;
        public static bool default_bold = true; 
        public static bool default_italic = false;
        public static Color default_color = new Color(255, 255, 255, 255);

        public string name;
        public float size;
        public bool bold;
        public bool italic;
        public Color color;

        public Font() : this(default_name)
        {
        }

        public Font(string name) : this(name, default_size)
        {
        }

        public Font(string name, float size)
        {
            this.name = name;
            this.size = size;
            this.bold = default_bold;
            this.italic = default_italic;
            this.color = default_color.color();
        }

        public bool existQM()
        {
            return true;
        }
    }
}
