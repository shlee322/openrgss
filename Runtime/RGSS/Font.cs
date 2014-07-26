using System.Collections.Generic;
using System.Drawing;

namespace OpenRGSS.Runtime.RGSS
{
    public class Font
    {
        public static string default_name = "Arial";
        public static float default_size = 22;
        public static bool default_bold = false; 
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

        public System.Drawing.Font GetNative()
        {
            FontStyle style = FontStyle.Regular;
            if (this.bold) style |= FontStyle.Bold;
            if (this.italic) style |= FontStyle.Italic;

            return new System.Drawing.Font(this.name, this.size, style, GraphicsUnit.Pixel);
        }
    }
}
