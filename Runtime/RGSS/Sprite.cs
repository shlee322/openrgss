namespace OpenRGSS.Runtime.RGSS
{
    public class Sprite
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }

        public Bitmap bitmap;
        public Rect src_rect;
        public bool visible;
        public int x;
        public int y;
        public int z;
        public int ox;
        public int oy;
        public double zoom_x;
        public double zoom_y;
        public int angle;
        public bool mirror;
        public int bush_depth;
        public int opacity;
        public int blend_type;
        public Color color;
        public Tone tone;

        public Sprite(Viewport viewport = null)
        {
        }

        public void dispose()
        {
        }

        public bool disposedQM()
        {
            return false;
        }

        public void flash(Color color, int duration)
        {
        }

        public void update()
        {
        }
    }
}
