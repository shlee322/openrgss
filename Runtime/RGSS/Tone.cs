using System.IO;

namespace OpenRGSS.Runtime.RGSS
{
    public class Tone
    {
        public double red;
        public double green;
        public double blue;
        public double gray;

        public Tone(double r, double g, double b, double a = 255)
        {
            this.set(r, g, b, a);
        }

        public void set(double r, double g, double b, double a = 255)
        {
            this.red = r;
            this.green = g;
            this.blue = b;
            this.gray = a;
        }

        public Color color()
        {
            return new Color(this.red, this.green, this.blue, this.gray);
        }

        public static Tone _load(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    double r = reader.ReadDouble();
                    double g = reader.ReadDouble();
                    double b = reader.ReadDouble();
                    double a = reader.ReadDouble();

                    return new Tone(r, g, b, a);
                }
            }
        }

        public byte[] _dump(int d = 0)
        {
            return null;
        }
    }
}
