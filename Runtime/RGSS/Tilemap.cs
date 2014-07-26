using OpenTK.Graphics.OpenGL;
namespace OpenRGSS.Runtime.RGSS
{
    public class Tilemap : Entity
    {
        private static int[] AUTOTILES = new int[] {
            27, 28, 33, 34,     5, 28, 33, 34,      27,  6, 33, 34,     5,  6, 33, 34,
            27, 28, 33, 12,     5, 28, 33, 12,      27,  6, 33, 12,     5,  6, 33, 12,

            27, 28, 11, 34,     5, 28, 11, 34,      27,  6, 11, 34,     5,  6, 11, 34,
            27, 28, 11, 12,     5, 28, 11, 12,      27,  6, 11, 12,     5,  6, 11, 12,

            25, 26, 31, 32,     25,  6, 31, 32,     25, 26, 31, 12,     25,  6, 31, 12,
            15, 16, 21, 22,     15, 16, 21, 12,     15, 16, 11, 22,     15, 16, 11, 12,

            29, 30, 35, 36,     29, 30, 11, 36,     5, 30, 35, 36,      5, 30, 11, 36,
            39, 40, 45, 46,     5, 40, 45, 46,      39,  6, 45, 46,     5,  6, 45, 46,

            25, 30, 31, 36,     15, 16, 45, 46,     13, 14, 19, 20,     13, 14, 19, 12,
            17, 18, 23, 24,     17, 18, 11, 24,     41, 42, 47, 48,     5, 42, 47, 48,

            37, 38, 43, 44,     37,  6, 43, 44,     13, 18, 19, 24,     13, 14, 43, 44,
            37, 42, 43, 48,     17, 18, 47, 48,     13, 18, 43, 48,     1,  2,  7,  8
        };

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
        public bool visible = true;
        public int ox;
        public int oy;

        private int frame;

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
            if (!this.visible) return;

            GL.BindTexture(TextureTarget.Texture2D, this.tileset.TextureId);

            GL.Begin(PrimitiveType.Quads);

            for (int z = 0; z < this.map_data.zsize; z++)
            {
                for(int y = 0; y<this.map_data.ysize; y++)
                {
                    for (int x = 0; x < this.map_data.xsize; x++)
                    {
                        int dx = x * 32 - this.ox;
                        int dy = y * 32 - this.oy;

                        if (dx < -32 || dx > Engine.GetInstance().Width) continue;
                        if (dx < -32 || dy > Engine.GetInstance().Height) continue;

                        short tile_id = this.map_data[x, y, z];

                        int dz = this.viewport.GetDisplayZ(this.priorities[tile_id] == 0 ? 0 : y + this.priorities[tile_id] * 32 + 32);

                        if (tile_id >= 384)
                        {
                            int tile_x = (tile_id - 384) % 8 * 32;
                            int tile_y = (tile_id - 384) / 8 * 32;

                            double src_x = tile_x * 1.0 / this.tileset.width;
                            double src_y = tile_y * 1.0 / this.tileset.height;
                            double src_w = (tile_x + 32) * 1.0 / this.tileset.width;
                            double src_h = (tile_y + 32) * 1.0 / this.tileset.height;

                            GL.TexCoord2(src_x, src_y); GL.Vertex3(dx, dy, dz);
                            GL.TexCoord2(src_x, src_h); GL.Vertex3(dx, dy + 32, dz);
                            GL.TexCoord2(src_w, src_h); GL.Vertex3(dx + 32, dy + 32, dz);
                            GL.TexCoord2(src_w, src_y); GL.Vertex3(dx + 32, dy, dz);
                        }
                        else if(tile_id>47)
                        {
                            GL.End();

                            Bitmap autotile = this.autotiles[tile_id / 48 - 1];
                            int autotile_xp = ((frame/15)%(autotile.width/96)) * 96;
                            int autotile_id = tile_id % 48;

                            GL.BindTexture(TextureTarget.Texture2D, autotile.TextureId);

                            GL.Begin(PrimitiveType.Quads);

                            for (int i = 0; i < 4; i++)
                            {
                                int tilePosition = Tilemap.AUTOTILES[(autotile_id >> 3) * 4 * 8 + 4 * (autotile_id & 7) + i] - 1;
                                int autotile_x = (tilePosition % 6) * 16 + autotile_xp;
                                int autotile_y = (tilePosition / 6) * 16;
                                double src_x = autotile_x * 1.0 / autotile.width;
                                double src_y = autotile_y * 1.0 / autotile.height;
                                double src_w = (autotile_x + 16) * 1.0 / autotile.width;
                                double src_h = (autotile_y + 16) * 1.0 / autotile.height;

                                GL.TexCoord2(src_x, src_y); GL.Vertex3(i % 2 * 16 + dx, i / 2 * 16 + dy, dz);
                                GL.TexCoord2(src_x, src_h); GL.Vertex3(i % 2 * 16 + dx, i / 2 * 16 + dy + 16, dz);
                                GL.TexCoord2(src_w, src_h); GL.Vertex3(i % 2 * 16 + dx + 16, i / 2 * 16 + dy + 16, dz);
                                GL.TexCoord2(src_w, src_y); GL.Vertex3(i % 2 * 16 + dx + 16, i / 2 * 16 + dy, dz);
                            }

                            GL.End();

                            GL.BindTexture(TextureTarget.Texture2D, this.tileset.TextureId);

                            GL.Begin(PrimitiveType.Quads);
                        }
                    }
                }
            }
            GL.End();

            this.frame = (this.frame + 1) % 1200;
        }
    }
}
