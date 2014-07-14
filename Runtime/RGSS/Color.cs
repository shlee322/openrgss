using System.IO;

namespace OpenRGSS.Runtime.RGSS
{
    public class Color
    {
        public double red;
        public double green;
        public double blue;
        public double alpha;

        public Color(double r, double g, double b, double a = 255)
        {
            this.set(r, g, b, a);
        }

        public void set(double r, double g, double b, double a = 255)
        {
            this.red = r;
            this.green = g;
            this.blue = b;
            this.alpha = a;
        }

        public Color color()
        {
            return new Color(this.red, this.green, this.blue, this.alpha);
        }

        public static Color _load(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    double r = reader.ReadDouble();
                    double g = reader.ReadDouble();
                    double b = reader.ReadDouble();
                    double a = reader.ReadDouble();

                    return new Color(r, g, b, a);
                }
            }
        }

        public byte[] _dump(int d = 0)
        {
            return null;
        }

        public System.Drawing.Color GetNative()
        {
            return System.Drawing.Color.FromArgb((int)this.alpha, (int)this.red, (int)this.green, (int)this.blue);
        }
    }
}
