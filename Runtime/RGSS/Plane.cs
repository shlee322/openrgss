﻿namespace OpenRGSS.Runtime.RGSS
{
    public class Plane : Entity
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }
        public Bitmap bitmap;
        public bool visible = true;
        public int z;
        public int ox;
        public int oy;
        public double zoom_x;
        public double zoom_y;
        public int _opacity;
        public int opacity
        {
            get
            {
                return this._opacity;
            }

            set
            {
                this._opacity = value;
                if (this._opacity < 0) this._opacity = 0;
                else if (this._opacity > 255) this._opacity = 255;
            }
        }

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
            if (!this.visible) return;
        }
    }
}
