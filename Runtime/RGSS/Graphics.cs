using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace OpenRGSS.Runtime.RGSS
{
    public class Graphics
    {
        public static int frame_rate
        {
            get
            {
                return Engine.GetInstance().GetFrameRate();
            }
        }
        public static int frame_count;

        private static IList<Viewport> viewportList = new List<Viewport>();
        
        public static void update()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0, 0 , 0, 1);

            foreach(Viewport viewport in viewportList) {
                viewport.draw();
            }

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

        public static void addViewport(Viewport viewport)
        {
            viewportList.Add(viewport);
        }
    }
}
