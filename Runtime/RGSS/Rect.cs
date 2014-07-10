namespace OpenRGSS.Runtime.RGSS
{
    public class Rect
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public Rect(int x, int y, int width, int height)
        {
            this.set(x, y, width, height);
        }

        public void set(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
