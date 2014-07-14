using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

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

        private List<Entity> entityList = new List<Entity>();

        public Viewport() : this(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height)
        {
        }

        public Viewport(int x, int y, int width, int height) : this(new Rect(x, y, width, height))
        {
        }

        public Viewport(Rect rect)
        {
            this.rect = rect;
            Graphics.addViewport(this);
        }

        public void dispose()
        {
            System.Console.WriteLine("Viewoprt Dispose");
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

        public void draw()
        {
            GL.Viewport(Engine.GetInstance().Width - this.rect.width + this.rect.x,
                Engine.GetInstance().Height - this.rect.height + this.rect.y,
                this.rect.width,
                this.rect.height);

            foreach (Entity entity in this.entityList)
            {
                entity.Draw();
            }
        }

        public void AddEntity(Entity entity)
        {
            this.entityList.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            this.entityList.Remove(entity);
        }
    }
}
