namespace OpenRGSS.Runtime.RGSS
{
    public class Viewport
    {
        public Rect rect;
        public bool visible;
        public int z;
        public int ox;
        public int oy;
        public Color color;
        public Tone tone;

        public Viewport(int x, int y, int width, int height)
        {
        }

        public Viewport(Rect rect)
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
