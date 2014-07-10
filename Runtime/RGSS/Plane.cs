namespace OpenRGSS.Runtime.RGSS
{
    public class Plane
    {
        public Viewport viewport;
        public Bitmap bitmap;
        public bool visible;
        public int z;
        public int ox;
        public int oy;
        public double zoom_x;
        public double zoom_y;
        public int opacity;
        public int blend_type;
        public Color color;
        public Tone tone;

        public Plane(Viewport viewport = null)
        {
        }

        public void dispose()
        {
        }

        public bool disposedQM()
        {
            return false;
        }
    }
}
