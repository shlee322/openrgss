using OpenTK.Graphics.OpenGL;
namespace OpenRGSS.Runtime.RGSS
{
    public class Sprite : Entity
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }

        public Bitmap _bitmap;
        public Bitmap bitmap
        {
            get
            {
                return this._bitmap;
            }
            set
            {
                this._bitmap = value;
                this.src_rect.set(0, 0, this._bitmap.width, this._bitmap.height);
            }
        }

        public Rect src_rect = new Rect(0, 0, 640, 480);
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


        public Sprite() : this(null)
        {
        }

        public Sprite(Viewport viewport = null)
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

        public void flash(Color color, int duration)
        {
        }

        public void update()
        {
            //System.Console.WriteLine("Sprite Update");
        }

        public void Draw()
        {
            if (this.bitmap == null) return;
            GL.BindTexture(TextureTarget.Texture2D, this.bitmap.TextureId);
            GL.Begin(PrimitiveType.Quads);

            double src_x = this.src_rect.x * 1.0 / this.bitmap.width;
            double src_y = this.src_rect.y * 1.0 / this.bitmap.height;
            double src_w = (this.src_rect.x + this.src_rect.width) * 1.0 / this.bitmap.width;
            double src_h = (this.src_rect.y + this.src_rect.height) * 1.0 / this.bitmap.height;

            int dx = this.x - this.ox;
            int dy = this.y - this.oy;

            GL.TexCoord2(src_x, src_y); GL.Vertex3(dx, dy, this.z);
            GL.TexCoord2(src_x, src_h); GL.Vertex3(dx, dy + this.src_rect.height, this.z);
            GL.TexCoord2(src_w, src_h); GL.Vertex3(dx + this.src_rect.width, dy + this.src_rect.height, this.z);
            GL.TexCoord2(src_w, src_y); GL.Vertex3(dx + this.src_rect.width, dy, this.z);
            GL.End();
        }
    }
}
