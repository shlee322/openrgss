namespace OpenRGSS.Runtime.RGSS
{
    public class Window
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }
        public Bitmap windowskin;
        public Bitmap contents;
        public bool stretch;
        public Rect cursor_rect = new Rect(0 ,0, 640, 340);
        public bool active;
        public bool visible;
        public bool pause;
        public int x;
        public int y;
        public int z;
        public int width;
        public int height;
        public int ox;
        public int oy;
        public int opacity;
        public int back_opacity;
        public int contents_opacity;

        public Window()
        {
        }

        public Window(Viewport viewport = null)
        {
        }

        public void dispose()
        {
        }

        public bool disposedQM()
        {
            return false;
        }

        public void update()
        {
        }
    }
}
