using System;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Weather : Entity
    {
        private static Random rand = new Random();

        private Viewport _viewport;
        public Viewport viewport
        {
            get { return _viewport; }
        }

        public int _type;
        public int _max;
        public int _ox;
        public int _oy;
        public Bitmap rain_bitmap;
        public Bitmap storm_bitmap;
        public Bitmap snow_bitmap;
        public Sprite[] sprites;

        public Weather(Viewport viewport = null)
        {
            if (viewport == null)
            {
                viewport = new Viewport();
            }

            this._viewport = viewport;

            this.viewport.AddEntity(this);

            Color color1 = new Color(255, 255, 255, 255);
            Color color2 = new Color(255, 255, 255, 128);

            this.rain_bitmap = new Bitmap(7, 56);
            for (int i = 0; i < 7; i++)
            {
                this.rain_bitmap.fill_rect(6 - i, i * 8, 1, 8, color1);
            }
            this.storm_bitmap = new Bitmap(34, 64);
            for(int i=0; i<32; i++)
            {
                this.storm_bitmap.fill_rect(33-i, i*2, 1, 2, color2);
                this.storm_bitmap.fill_rect(32-i, i*2, 1, 2, color1);
                this.storm_bitmap.fill_rect(31 - i, i * 2, 1, 2, color2);
            }
            
            this.snow_bitmap = new Bitmap(6, 6);
            this.snow_bitmap.fill_rect(0, 1, 6, 4, color2);
            this.snow_bitmap.fill_rect(1, 0, 4, 6, color2);
            this.snow_bitmap.fill_rect(1, 2, 4, 2, color1);
            this.snow_bitmap.fill_rect(2, 1, 2, 4, color1);

            this.sprites = new Sprite[41];
            for(int i=1; i<41; i++) {
                Sprite sprite = new Sprite(viewport);
                sprite.z = 1000;
                sprite.visible = false;
                sprite.opacity = 0;
                this.sprites[i] = sprite;
            }
        }

        public void dispose()
        {
            foreach(Sprite sprite in this.sprites) {
                if (sprite == null) continue;
                sprite.dispose();
            }
            this.rain_bitmap.dispose();
            this.storm_bitmap.dispose();
            this.snow_bitmap.dispose();
            this.viewport.RemoveEntity(this);
        }

        public bool disposedQM()
        {
            return false;
        }

        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (this._type == value) return;
                this._type = value;

                Bitmap bitmap;

                switch(this._type)
                {
                    case 1:
                        bitmap = this.rain_bitmap;
                        break;
                    case 2:
                        bitmap = this.storm_bitmap;
                        break;
                    case 3:
                        bitmap = this.snow_bitmap;
                        break;
                    default:
                        bitmap = null;
                        break;
                }

                for(int i=1; i<41; i++) {
                    Sprite sprite = this.sprites[i];
                    if(sprite == null) continue;
                    sprite.visible = (i <= this.max);
                    sprite.bitmap = bitmap;
                }
            }
        }

        public int ox
        {
            get
            {
                return this._ox;
            }

            set
            {
                if (this._ox == value) return;
                this._ox = value;
                foreach(Sprite sprite in this.sprites)
                {
                    if (sprite == null) continue;
                    sprite.ox = this._ox;
                }
            }
        }

        public int oy
        {
            get
            {
                return this._oy;
            }

            set
            {
                if (this._oy == value) return;
                this._oy = value;
                foreach (Sprite sprite in this.sprites)
                {
                    if (sprite == null) continue;
                    sprite.oy = this._oy;
                }
            }
        }

        public int max
        {
            get
            {
                return this._max;
            }

            set
            {
                if (this._max == value) return;
                this._max = value < 0 ? 0 : value > 40 ? 40 : value;
                for (int i = 1; i < 41; i++)
                {
                    Sprite sprite = this.sprites[i];
                    if (sprite == null) continue;
                    sprite.visible = (i <= this._max);
                }
            }
        }

        public void update()
        {
            if (this.type == 0) return;

            for (int i = 1; i <= this.max; i++)
            {
                Sprite sprite = this.sprites[i];
                if (sprite == null) continue;
                if (this.type == 1)
                {
                    sprite.x -= 2;
                    sprite.y += 16;
                    sprite.opacity -= 8;
                }
                if(this.type == 2)
                {
                  sprite.x -= 8;
                  sprite.y += 16;
                  sprite.opacity -= 12;
                }
                if(this.type == 3)
                {
                    sprite.x -= 2;
                    sprite.y += 8;
                    sprite.opacity -= 8;
                }

                int x = sprite.x - this.ox;
                int y = sprite.y - this.oy;
                if(sprite.opacity < 64 || x < -50 || x > 750 || y < -300 || y > 500)
                {
                    sprite.x = rand.Next(800) - 50 + this.ox;
                    sprite.y = rand.Next(800) - 200 + this.oy;
                    sprite.opacity = 255;
                }
            }
        }

        public void Draw()
        {
        }
    }
}