namespace OpenRGSS.Runtime.RGSS
{
    public class Plane : Entity
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }
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
            if (viewport == null)
            {
                viewport = new Viewport();
            }
            this._viewport = viewport;
            this.viewport.AddEntity(this);
        }

        public void dispose()
        {
            if(this.bitmap != null) this.bitmap.dispose();
            this.viewport.RemoveEntity(this);
        }

        public bool disposedQM()
        {
            return false;
        }

        public void Draw()
        {
        }
    }
}
