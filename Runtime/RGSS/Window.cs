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
        public Rect cursor_rect = new Rect(0 ,0, Engine.GetInstance().Width, Engine.GetInstance().Height);
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
        public int opacity = 255;
        public int back_opacity = 200;
        public int contents_opacity = 255;
        
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
            this.contents.dispose();
            this.viewport.RemoveEntity(this);
        }

        public bool disposedQM()
        {
            return false;
        }

        public void update()
        {
            //stem.Console.WriteLine("Window Update");
        }

        public void Draw()
        {
            
            GL.BindTexture(TextureTarget.Texture2D, this.windowskin.TextureId);
            GL.Begin(PrimitiveType.Quads);

            //메인 틀
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(this.x, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(this.x, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 1.0f); GL.Vertex3(this.x + this.width, this.y + this.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 0.0f); GL.Vertex3(this.x + this.width, this.y, this.viewport.GetDisplayZ(this.z));
            
            //*
            //좌측 상단 테두리
            GL.TexCoord2(Window.Boundary, 0.0f); GL.Vertex3(this.x, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary, 1f / 8f); GL.Vertex3(this.x, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 1f / 8f); GL.Vertex3(this.x + 64 / 8, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + 64 / 8, this.y, this.viewport.GetDisplayZ(this.z));

            //상단 중앙 테두리
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 0.0f); GL.Vertex3(this.x + 64 / 8, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary, 1f / 8f); GL.Vertex3(this.x + 64 / 8, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary * 2, 1f / 8f); GL.Vertex3(this.x + this.width - 64 / 8, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary * 2, 0.0f); GL.Vertex3(this.x + this.width - 64 / 8, this.y, this.viewport.GetDisplayZ(this.z));

            //우측 상단 테두리
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary * 2, 0.0f); GL.Vertex3(this.x + this.width - 64 / 8, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(Window.Boundary + Window.BorderBoundary * 2, 1f / 8f); GL.Vertex3(this.x + this.width - 64 / 8, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 1f / 8f); GL.Vertex3(this.x + this.width, this.y + 64 / 8, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(this.x + this.width, this.y, this.viewport.GetDisplayZ(this.z));

            //커서
            GL.TexCoord2(2 / 3f, 0.5f); GL.Vertex3(this.x + this.cursor_rect.x, this.y + this.cursor_rect.y, this.viewport.GetDisplayZ(this.z + 1));
            GL.TexCoord2(2 / 3f, 0.75f); GL.Vertex3(this.x + this.cursor_rect.x, this.y + this.cursor_rect.y + this.cursor_rect.height, this.viewport.GetDisplayZ(this.z + 1));
            GL.TexCoord2(2 / 3f + 1 / 6f, 0.75f); GL.Vertex3(this.x + this.cursor_rect.x + this.cursor_rect.width, this.y + this.cursor_rect.y + this.cursor_rect.height, this.viewport.GetDisplayZ(this.z + 1));
            GL.TexCoord2(2 / 3f + 1 / 6f, 0.5f); GL.Vertex3(this.x + this.cursor_rect.x + this.cursor_rect.width, this.y + this.cursor_rect.y, this.viewport.GetDisplayZ(this.z + 1));
            //*/
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, this.contents.TextureId);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(this.x, this.y, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(this.x, this.y + this.contents.rect.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(this.x + this.contents.rect.width, this.y + this.contents.rect.height, this.viewport.GetDisplayZ(this.z));
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(this.x + this.contents.rect.width, this.y, this.viewport.GetDisplayZ(this.z));
            GL.End();
        }
    }
}
