using System;
using System.Collections;
using System.Threading;
using Microsoft.Scripting.Hosting;
using IronRuby;
using OpenTK;
using OpenTK.Graphics;
using System.Collections.Generic;
using Microsoft.Scripting;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace OpenRGSS
{
    public class Engine
    {
        private static Engine instance;

        private GameWindow window;
        private Thread gameThread;
        private ScriptEngine rubyEngine;

        private IntroScene introScene;

        private bool _debug;

        private const string RGSSRuntimeSource = @"
            require 'OpenRGSS.Runtime.RGSS'
            include OpenRGSS::Runtime::RGSS

            class Input
	            class << self
		            def press?(num)
			            return pressQM(num.getKey())
		            end
		            def trigger?(num)
			            return triggerQM(num.getKey())
		            end
		            def repeat?(num)
			            return repeatQM(num.getKey())
		            end
	            end
            end

            def load_data(filename)
                File.open(filename, 'rb') { |f|
                    return Marshal.load(f)
                }
            end

            def save_data(obj, filename)
                File.open(filename, 'wb') { |f|
                  Marshal.dump(obj, f)
                }
            end

            def print(msg)
                Engine.Log(msg)
            end
        ";
        private const string ScriptLoaderSource = @"
            load_assembly 'IronRuby.Libraries', 'IronRuby.StandardLibrary.Zlib'

            f = File.open('Data/Scripts.rxdata', 'rb')
            obj = Marshal.load(f)
            for script in obj
                Engine.LoadScript(script[1], Zlib::Inflate.inflate(script[2]))
            end

            Engine.Exit()
        ";

        public int Width
        {
            get
            {
                return this.window.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.window.Height;
            }
        }

        public bool Debug
        {
            get
            {
                return this._debug;
            }

            set
            {
                this._debug = value;

                if (this.rubyEngine != null)
                {
                    this.rubyEngine.Runtime.Globals.SetVariable("DEBUG", this.Debug);
                }
            }
        }

        public Engine()
        {
            this.SetInstance();

            this.window = new GameWindow(640, 480);
            this.window.Title = "OpenRGSS";
            this.window.Load += LoadWindow;

            this.gameThread = new Thread(this.EngineThreadMain);
            this.introScene = new IntroScene();
        }

        public static Engine GetInstance()
        {
            return Engine.instance;
        }

        protected static void SetInstance(Engine engine)
        {
            Engine.instance = engine;
        }

        protected void SetInstance()
        {
            Engine.SetInstance(this);
        }

        public void Run()
        {
            this.window.Run();
        }

        public void Exit()
        {
            this.window.Exit();
        }

        private void LoadWindow(object sender, System.EventArgs e)
        {
            this.window.Context.MakeCurrent(null);
            this.gameThread.Start();
        }

        protected void EngineThreadMain()
        {
            this.window.MakeCurrent();
            this.InitEngine();
            this.introScene.Init();
            this.introScene.Log("Init Engine...");
            this.InitScriptEngine();
            this.InitScripts();
        }

        protected void InitEngine()
        {
            GL.Ortho(0.0, Engine.GetInstance().Width, Engine.GetInstance().Height, 0.0, 100000, -100000);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.ShadeModel(ShadingModel.Smooth);
        }

        protected void InitScriptEngine()
        {
            this.introScene.Log("Init Script Engine...");

            ScriptRuntime runtime = Ruby.CreateRuntime();
            this.rubyEngine = runtime.GetEngine("rb");

            this.rubyEngine.Runtime.Globals.SetVariable("Engine", this);
            this.rubyEngine.Runtime.Globals.SetVariable("DEBUG", this.Debug);
        }

        protected void InitScripts()
        {
            this.introScene.Log("Init Scripts...");
            this.LoadScript("RGSS Runtime", Engine.RGSSRuntimeSource);
            this.LoadScript("Scripts Loader", Engine.ScriptLoaderSource);
        }

        public void LoadScript(string name, string src)
        {
            ScriptSource source = this.rubyEngine.CreateScriptSourceFromString(src, name, SourceCodeKind.File);

            try
            {
                this.introScene.Log("Load Script (" + name + ")...");
                source.Execute();
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        private void ShowError(Exception e)
        {
            foreach (DictionaryEntry data in e.Data)
            {
                if (data.Value is IronRuby.Runtime.RubyExceptionData)
                {
                    IronRuby.Runtime.RubyExceptionData exData = (IronRuby.Runtime.RubyExceptionData)data.Value;

                    OpenRGSS.Log.Debug(exData.Message.ToString());
                    foreach (var ex in exData.Backtrace)
                    {
                        OpenRGSS.Log.Debug(ex.ToString());
                    }
                }
            }

            OpenRGSS.Log.Debug("=======================");
            OpenRGSS.Log.Debug(e.ToString());

            int errorTexture = -1;
            using (Bitmap buffer = OpenRGSS.Properties.Resources.OPENRGSS_ERROR)
            {
                errorTexture = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, errorTexture);

                System.Drawing.Imaging.BitmapData data = buffer.LockBits(new Rectangle(0, 0, buffer.Width, buffer.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                buffer.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Nearest);
            }

            while(true)
            {
                GL.Viewport(0, 0, Engine.GetInstance().Width, Engine.GetInstance().Height);

                GL.ClearColor(0, 0, 0, 1);

                GL.BindTexture(TextureTarget.Texture2D, errorTexture);
                GL.Begin(PrimitiveType.Quads);

                GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);

                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(0, 0);
                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(0, 480);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(640, 480);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(640, 0);

                GL.End();

                SwapBuffers();
            }
        }

        private long tick = 0;
        private long count = 0;
        private long aCount = 0;

        public void SwapBuffers()
        {
            if (this.window.IsExiting)
            {
                Thread.CurrentThread.Abort();
            }

            count++;
            if (System.DateTime.Now.Ticks > tick)
            {
                tick = System.DateTime.Now.Ticks + 10000000;
                aCount = count;
                count = 0;

                this.window.Title = "OpenRGSS - FPS : " + aCount;
            }

            this.window.SwapBuffers();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0, 0, 0, 1);
        }

        public GameWindow GetWindow()
        {
            return this.window;
        }

        public void Log(string msg)
        {
            OpenRGSS.Log.Debug(msg);
        }

        public int GetFrameRate()
        {
            return 60;
        }
    }
}
