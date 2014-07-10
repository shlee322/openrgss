using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace OpenRGSS.Runtime.RGSS
{
    public class Graphics
    {
        public static int frame_rate;
        public static int frame_count;

        private static IList<Viewport> viewportList;

        public static void update()
        {
            GL.ClearColor(0, 0, 0, 1);
            Engine.GetInstance().SwapBuffers();
        }

        public static void freeze()
        {
        }

        public static void transition(int duration = 8, string filename = null, int vague = 40)
        {
        }

        public static void frame_reset()
        {
        }
    }
}
