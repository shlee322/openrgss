namespace OpenRGSS.Runtime.RGSS
{
    public class Bitmap
    {
        public int width;
        public int height;
        public Rect rect;
        public Font font = new Font();

        public Bitmap(string filename)
        {
            this.rect = new Rect(0, 0, 640, 340);
        }

        public Bitmap(int width, int height)
        {
            this.rect = new Rect(0, 0, width, height);
        }

        public void dispose()
        {
        }

        public bool disposedQM()
        {
            return false;
        }

        public void blt(int x, int y, Bitmap src_bitmap, Rect src_rect, int opacity=0)
        {
        }

        public void stretch_blt(Rect dest_rect, Bitmap src_bitmap, Rect src_rect, int opacity=0)
        {
        }

        public void fill_rect(int x, int y, int width, int height, Color color)
        {
        }

        public void fill_rect(Rect rect, Color color)
        {
        }

        public Bitmap clone()
        {
            return null;
        }

        public void clear()
        {
        }

        public Color get_pixel(int x, int y)
        {
            return null;
        }

        public void set_pixel(int x, int y, Color color)
        {
        }

        public void hue_change(int hug)
        {
        }

        public void draw_text(int x, int y, int width, int height, string str, int align=0)
        {
        }

        public void draw_text(Rect rect, string str, int align=0)
        {
        }

        public void text_size(string str)
        {
        }
    }
}
