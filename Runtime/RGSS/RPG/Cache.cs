using System;
using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class Cache
    {
        private static Dictionary<string, Bitmap> cache = new Dictionary<string, Bitmap>();

        public static Bitmap load_bitmap(string folder_name, string filename, int hue = 0)
        {
            string path = folder_name + filename;

            if (!cache.ContainsKey(path) || cache[path].disposedQM())
            {
                if (filename != "")
                {
                    cache[path] = new Bitmap(path);
                }
                else
                {
                    cache[path] = new Bitmap(32, 32);
                }
            }

            if (hue == 0)
            {
                return cache[path];
            }

            string key = path + "/" + hue;
            if (!cache.ContainsKey(key) || cache[key].disposedQM())
            {
                cache[key] = cache[path].clone();
                cache[key].hue_change(hue);
            }

            return cache[key];
        }

        public static Bitmap animation(string filename, int hue)
        {
            return load_bitmap("Graphics/Animations/", filename, hue);
        }

        public static Bitmap autotile(string filename)
        {
            return load_bitmap("Graphics/Autotiles/", filename);
        }

        public static Bitmap battleback(string filename)
        {
            return load_bitmap("Graphics/Battlebacks/", filename);
        }

        public static Bitmap battler(string filename, int hue)
        {
            return load_bitmap("Graphics/Battlers/", filename, hue);
        }

        public static Bitmap character(string filename, int hue)
        {
            return load_bitmap("Graphics/Characters/", filename, hue);
        }

        public static Bitmap fog(string filename, int hue)
        {
            return load_bitmap("Graphics/Fogs/", filename, hue);
        }

        public static Bitmap gameover(string filename)
        {
            return load_bitmap("Graphics/Gameovers/", filename);
        }

        public static Bitmap icon(string filename)
        {
            return load_bitmap("Graphics/Icons/", filename);
        }

        public static Bitmap panorama(string filename, int hue)
        {
            return load_bitmap("Graphics/Panoramas/", filename, hue);
        }

        public static Bitmap picture(string filename)
        {
            return load_bitmap("Graphics/Pictures/", filename);
        }

        public static Bitmap tileset(string filename)
        {
            return load_bitmap("Graphics/Tilesets/", filename);
        }

        public static Bitmap title(string filename)
        {
            return load_bitmap("Graphics/Titles/", filename);
        }

        public static Bitmap windowskin(string filename)
        {
            return load_bitmap("Graphics/Windowskins/", filename);
        }

        public static Bitmap tile(string filename, int tile_id, int hue)
        {
            string key = filename + "/" + tile_id + "/" + hue;

            if (!cache.ContainsKey(key) || cache[key].disposedQM())
            {
                cache[key] = new Bitmap(32, 32);
                int x = (tile_id - 384) % 8 * 32;
                int y = (tile_id - 384) / 8 * 32;
                Rect rect = new Rect(x, y, 32, 32);
                @cache[key].blt(0, 0, tileset(filename), rect);
                @cache[key].hue_change(hue);
            }

            return cache[key];
        }

        public static void clear()
        {
            cache.Clear();
            GC.Collect();
        }
    }
}