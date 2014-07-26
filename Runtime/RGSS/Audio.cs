﻿namespace OpenRGSS.Runtime.RGSS
{
    public class Audio
    {
        private static string[] AudioExtension = new string[] { ".mid", ".ogg", ".mp3" };

        public static void bgm_play(string filename, int volume=100, int pitch=100)
        {
        }

        public static void bgm_stop()
        {
        }

        public static void bgm_fade(int time)
        {
        }

        public static void bgs_play(string filename, int volume=100, int pitch=100)
        {
        }

        public static void bgs_stop()
        {
        }

        public static void bgs_fade(int time)
        {
        }

        public static void me_play(string filename, int volume = 100, int pitch = 100)
        {
        }

        public static void me_stop()
        {
        }

        public static void me_fade(int time)
        {
        }

        public static void se_play(string filename, int volume = 100, int pitch = 100)
        {
        }

        public static void se_fade(int time)
        {
        }

        private static string FindFile(string filename)
        {
            foreach (string ext in AudioExtension)
            {
                if (System.IO.File.Exists(filename + ext))
                    return filename + ext;
            }

            return filename;
        }
    }
}
