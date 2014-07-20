using OpenTK.Graphics.OpenGL;

namespace OpenRGSS.Runtime.RGSS
{
    public class Window : Entity
    {
        private const float Boundary = 128f / 192f;
        private const float BorderBoundary = (64f / 192f) / 4f;

        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }
        public Bitmap windowskin;
        public Bitmap contents = new Bitmap(32, 32);
        public bool stretch;
        public Rect cursor_rect = new Rect(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height);
        public bool active = true;
        public bool visible = true;
        public bool pause;
        public int x;
        public int y;
        public int z = 100;
        public int width;
        public int height;
        public int ox = 0;
        public int oy = 0;
        public int _opacity = 255;
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

        public int _back_opacity = 200;
        public int back_opacity
        {
            get
            {
                return this._back_opacity;
            }

            set
            {
                this._back_opacity = value;
                if (this._back_opacity < 0) this._back_opacity = 0;
                else if (this._back_opacity > 255) this._back_opacity = 255;
            }
        }

        public int _contents_opacity = 255;
        public int contents_opacity
        {
            get
            {
                return this._contents_opacity;
            }

            set
            {
                this._contents_opacity = value;
                if (this._contents_opacity < 0) this._contents_opacity = 0;
                else if (this._contents_opacity > 255) this._contents_opacity = 255;
            }
        }

        private bool disposed;
        
        public Window() : this(null)
        {
        }

        public Window(Viewport viewport)
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
            this.windowskin.dispose();
            if(this.contents != null) this.contents.dispose();
            this.viewport.RemoveEntity(this);
            this.disposed = true;
        }

        public bool disposedQM()
        {
            return this.disposed;
        }

        public void update()
        {
        }

        public void Draw()
        {
            if (!this.visible || this.disposedQM()) return;

            GL.BindTexture(TextureTarget.Texture2D, this.windowskin.TextureId);

            GL.Begin(PrimitiveType.Quads);

            //메인 틀
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(this.x + 2, this.y + 2, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(this.x + 2, this.y + this.height - 2, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 1.0f); GL.Vertex3(this.x + this.width - 2, this.y + this.height - 2, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 0.0f); GL.Vertex3(this.x + this.width - 2, this.y + 2, this.viewport.GetDisplayZ(this.z));

            //좌측 상단 테두리
            GL.TexCoord2(Window.Boundary, 0.0f); GL.Vertex3(this.x, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 0.125f); GL.Vertex3(this.x, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + 16, this.y, this.viewport.GetDisplayZ(this.z));
            
            //상단 중앙 테두리
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + 16, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + this.width - 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + this.width - 16, this.y, this.viewport.GetDisplayZ(this.z));

            //우측 상단 테두리
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + this.width - 16, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + this.width - 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.125f); GL.Vertex3(this.x + this.width, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(this.x + this.width, this.y, this.viewport.GetDisplayZ(this.z));

            //좌측 테두리
            GL.TexCoord2(Window.Boundary, 0.125f); GL.Vertex3(this.x, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 0.375f); GL.Vertex3(this.x, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + 16, this.y + 16, this.viewport.GetDisplayZ(this.z));

            //우측 테두리
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.125f); GL.Vertex3(this.x + this.width - 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + this.width - 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.375f); GL.Vertex3(this.x + this.width, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.125f); GL.Vertex3(this.x + this.width, this.y + 16, this.viewport.GetDisplayZ(this.z));

            //좌측 하단 테두리
            GL.TexCoord2(Window.Boundary, 0.375f); GL.Vertex3(this.x, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 0.5f); GL.Vertex3(this.x, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.5f); GL.Vertex3(this.x + 16, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            
            //하단 중앙 테두리
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.5f); GL.Vertex3(this.x + 16, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.5f); GL.Vertex3(this.x + this.width - 16, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + this.width - 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));

            //우측 하단 테두리
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.375f); GL.Vertex3(this.x + this.width - 16, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f - Window.BorderBoundary, 0.5f); GL.Vertex3(this.x + this.width - 16, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(this.x + this.width, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.375f); GL.Vertex3(this.x + this.width, this.y + this.height - 16, this.viewport.GetDisplayZ(this.z));

            if (this.cursor_rect.width > 0 && this.cursor_rect.height > 0)
            {
                //커서 상단
                GL.TexCoord2(Window.Boundary, 0.5f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(1.0f - 0.167f, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(1.0f - 0.167f, 0.5f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y, this.viewport.GetDisplayZ(this.z + 1));

                //커서 좌측
                GL.TexCoord2(Window.Boundary, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary + 0.010416f, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + 2, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary + 0.010416f, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + 2, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));

                //커서 우측
                GL.TexCoord2(0.8229166f, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width - 2, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(0.8229166f, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width - 2, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(0.833f, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(0.833f, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));

                //커서 하단
                GL.TexCoord2(Window.Boundary, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary, 0.75f); GL.Vertex3(this.x + 16 + this.cursor_rect.x, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(1.0f - 0.167f, 0.75f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(1.0f - 0.167f, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + this.cursor_rect.width, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));

                //커서 배경
                GL.TexCoord2(Window.Boundary + 0.010416f, 0.515625f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + 2, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(Window.Boundary + 0.010416f, 0.734375f); GL.Vertex3(this.x + 16 + this.cursor_rect.x + 2, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(0.8229166f, 0.734375f); GL.Vertex3(this.x + this.cursor_rect.x + 16 + this.cursor_rect.width - 2, this.y + 16 + this.cursor_rect.y + this.cursor_rect.height - 2, this.viewport.GetDisplayZ(this.z + 1));
                GL.TexCoord2(0.8229166f, 0.515625f); GL.Vertex3(this.x + this.cursor_rect.x + 16 + this.cursor_rect.width - 2, this.y + 16 + this.cursor_rect.y + 2, this.viewport.GetDisplayZ(this.z + 1));
            }

            GL.End();

            if (this.contents == null) return;

            GL.BindTexture(TextureTarget.Texture2D, this.contents.TextureId);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(this.x + 16, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(this.x + 16, this.y + 16 + this.contents.rect.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(this.x + 16 + this.contents.rect.width, this.y + 16 + this.contents.rect.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(this.x + 16 + this.contents.rect.width, this.y + 16, this.viewport.GetDisplayZ(this.z));
            GL.End();
        }
    }
}
