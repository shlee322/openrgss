using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK.Graphics.OpenGL;

namespace OpenRGSS
{
    class IntroScene
    {
        private int msgTexture = -1;

        public void Log(string msg)
        {
            GL.Viewport(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height);
            //GL.Ortho(0.0, Engine.GetInstance().Width, Engine.GetInstance().Height, 0, 1, -1);

            GL.ClearColor(0, 0, 0, 1);
            setMessageTexutre(msg);

            GL.PushMatrix();
            GL.Translate(0, 0, 0);
            GL.Rotate(0d, 0d, 0d, 1d);

            GL.BindTexture(TextureTarget.Texture2D, msgTexture);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(0, 0);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(0, Engine.GetInstance().Height);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(Engine.GetInstance().Width, Engine.GetInstance().Height);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(Engine.GetInstance().Width, 0);
            
            GL.End();
            GL.PopMatrix();

            Engine.GetInstance().SwapBuffers();
        }

        private void setMessageTexutre(string msg)
        {
            //msgTexture 제거필요

            using (Bitmap buffer = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.Clear(Color.Transparent);
                    g.DrawString(msg, new Font("Tahoma", 12, FontStyle.Bold), Brushes.White, new RectangleF(0, 0, 640, 480));
                    g.Flush();
                }

                if (msgTexture != -1)
                {
                    GL.DeleteTexture(msgTexture);
                }

                msgTexture = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, msgTexture);

                System.Drawing.Imaging.BitmapData data = buffer.LockBits(new Rectangle(0, 0, buffer.Width, buffer.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                buffer.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);
            }
        }
    }
}
