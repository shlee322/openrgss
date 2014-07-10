namespace OpenRGSS.Runtime.RGSS
{
    public class Tilemap
    {
        public Viewport viewport;
        public Bitmap tileset;
        public Bitmap[] autotiles;
        public Table map_data;
        public Table flash_data;
        public Table priorities;
        public bool visible;
        public int ox;
        public int oy;

        public Tilemap(Viewport viewport = null)
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
