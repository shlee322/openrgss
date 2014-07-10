using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS
{
    public class Font
    {
        public static string default_name = "MS PMincho";
        public static int default_size = 22;
        public static bool default_bold = false; 
        public static bool default_italic = false;
        public static Color default_color = new Color(255, 255, 255, 255);

        public IList<string> name;
        public int size;
        public bool bold;
        public bool italic;
        public Color color;

        public Font()
        {
        }

        public Font(string name)
        {
        }

        public Font(string name, int size)
        {

        }

        public bool existQM()
        {
            return true;
        }
    }
}
