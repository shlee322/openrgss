namespace OpenRGSS.Runtime.RGSS
{
    public class Input
    {
        public enum Keys
        {
            C
        }

        public class Key {}
        public class C : Key { public static Keys getKey() { return Keys.C; } }

        public static void update()
        {
        }

        public static bool pressQM(Keys num)
        {
            return false;
        }

        public static bool triggerQM(Keys num)
        {
            return false;
        }

        public static bool repeatQM(Keys num)
        {
            return false;
        }

        public static int dir4()
        {
            return 0;
        }

        public static int dir8()
        {
            return 0;
        }
    }
}
