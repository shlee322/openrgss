using OpenTK.Graphics.OpenGL;
namespace OpenRGSS.Runtime.RGSS
{
    public class Tilemap : Entity
    {
        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }
        public Bitmap tileset;
        public Bitmap[] autotiles = new Bitmap[7];
        public Table map_data;
        public Table flash_data;
        public Table priorities;
        public bool visible;
        public int ox;
        public int oy;

        public Tilemap(Viewport viewport = null)
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
            this.tileset.dispose();
            for (int i = 0; i < 7; i++) if (this.autotiles[i] != null) this.autotiles[i].dispose();
            this.viewport.RemoveEntity(this);
        }

        public bool disposedQM()
        {
            return false;
        }

        public void update()
        {
        }

        public void Draw()
        {
            GL.BindTexture(TextureTarget.Texture2D, this.tileset.TextureId);
            GL.Begin(PrimitiveType.Quads);

            for (int z = 0; z < this.map_data.zsize; z++)
            {
                for(int y = 0; y<this.map_data.ysize; y++)
                {
                    for (int x = 0; x < this.map_data.xsize; x++)
                    {
                        short tile_id = this.map_data[x, y, z];
                        if (tile_id >= 384)
                        {
                            int tile_x = (tile_id - 384) % 8 * 32;
                            int tile_y = (tile_id - 384) / 8 * 32;

                            double src_x = tile_x * 1.0 / this.tileset.width;
                            double src_y = tile_y * 1.0 / this.tileset.height;
                            double src_w = (tile_x + 32) * 1.0 / this.tileset.width;
                            double src_h = (tile_y + 32) * 1.0 / this.tileset.height;

                            int dx = x * 32 - this.ox;
                            int dy = y * 32 - this.oy;

                            if (dx < -32 || dx > Engine.GetInstance().Width) continue;
                            if (dx < -32 || dy > Engine.GetInstance().Height) continue;

                            GL.TexCoord2(src_x, src_y); GL.Vertex3(dx, dy, 0);
                            GL.TexCoord2(src_x, src_h); GL.Vertex3(dx, dy + 32, 0);
                            GL.TexCoord2(src_w, src_h); GL.Vertex3(dx + 32, dy + 32, 0);
                            GL.TexCoord2(src_w, src_y); GL.Vertex3(dx + 32, dy, 0);
                        }
                    }
                }
            }
            GL.End();
        }
    }
}
