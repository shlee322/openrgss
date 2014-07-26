using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK.Graphics.OpenGL;

namespace OpenRGSS
{
    class IntroScene
    {
        private int licenseTexture = -1;
        private int logoTexture = -1;
        private int msgTexture = -1;
        private SizeF msgSize;
        private int licenseWidth = 0;
        private int licenseHeight = 0;

        public void Init()
        {
            InitLicense();
            InitLogo();

            for (int i = 0; i < 80; i++ )
            {
                GL.Viewport(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height);

                GL.ClearColor(0, 0, 0, 1);

                GL.PushMatrix();
                GL.Translate(0, 0, 0);

                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

                GL.Rotate(0d, 0d, 0d, 1d);

                GL.BindTexture(TextureTarget.Texture2D, licenseTexture);
                GL.Begin(PrimitiveType.Quads);
                
                GL.Color4(1.0f, 1.0f, 1.0f, i < 40 ? 1.0f : 1.0f-((i-40)/40f));

                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(0, 0);
                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(0, this.licenseHeight);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(this.licenseWidth, this.licenseHeight);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(this.licenseWidth, 0);

                GL.End();
                GL.PopMatrix();

                Engine.GetInstance().SwapBuffers();
            }

            GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
        }

        private void InitLicense()
        {
            using (Bitmap buffer = OpenRGSS.Properties.Resources.OPENRGSS_LICENSE)
            {
                this.licenseWidth = buffer.Width;
                this.licenseHeight = buffer.Height;

                licenseTexture = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, licenseTexture);

                System.Drawing.Imaging.BitmapData data = buffer.LockBits(new Rectangle(0, 0, buffer.Width, buffer.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                buffer.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);
            }
        }

        private void InitLogo()
        {
            using (Bitmap buffer = OpenRGSS.Properties.Resources.OPENRGSS_LOGO)
            {
                logoTexture = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, logoTexture);

                System.Drawing.Imaging.BitmapData data = buffer.LockBits(new Rectangle(0, 0, buffer.Width, buffer.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                buffer.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);
            }
        }

        public void Log(string msg)
        {
            OpenRGSS.Log.Debug(msg);

            GL.Viewport(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height);

            GL.ClearColor(0, 0, 0, 1);
            setMessageTexutre(msg);

            GL.PushMatrix();
            GL.Translate(0, 0, 0);
            GL.Rotate(0d, 0d, 0d, 1d);

            GL.BindTexture(TextureTarget.Texture2D, msgTexture);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(Engine.GetInstance().Width - this.msgSize.Width - 10, Engine.GetInstance().Height - this.msgSize.Height - 10);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(Engine.GetInstance().Width - this.msgSize.Width - 10, Engine.GetInstance().Height - this.msgSize.Height - 10 + Engine.GetInstance().Height);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(Engine.GetInstance().Width - this.msgSize.Width - 10 + Engine.GetInstance().Width, Engine.GetInstance().Height - this.msgSize.Height - 10 + Engine.GetInstance().Height);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(Engine.GetInstance().Width - this.msgSize.Width - 10 + Engine.GetInstance().Width, Engine.GetInstance().Height - this.msgSize.Height - 10);
            
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, logoTexture);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(62, 152);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(62, 152+177);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(62 + 517, 152+177);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(62 + 517, 152);

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
                    msgSize = g.MeasureString(msg, new Font("Tahoma", 12, FontStyle.Bold));
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
