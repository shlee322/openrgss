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

namespace OpenRGSS
{
    public class Engine
    {
        private static Engine instance;

        private GameWindow window;
        private Thread gameThread;
        private ScriptEngine rubyEngine;

        private IntroScene introScene;

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
            this.introScene.Log("Init Engine...");

            this.window.Context.MakeCurrent(null);
            this.gameThread.Start();
        }

        protected void EngineThreadMain()
        {
            this.window.MakeCurrent();
            this.InitEngine();
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
                foreach (DictionaryEntry data in e.Data)
                {
                    if (data.Value is IronRuby.Runtime.RubyExceptionData)
                    {
                        IronRuby.Runtime.RubyExceptionData exData = (IronRuby.Runtime.RubyExceptionData)data.Value;

                        System.Console.WriteLine(exData.Message.ToString());
                        foreach (var ex in exData.Backtrace)
                        {
                            System.Console.WriteLine(ex.ToString());
                        }
                    }
                }

                System.Console.WriteLine("=======================");
                System.Console.Write(e.ToString());
            }
        }

        private long tick = 0;
        private long count = 0;
        private long aCount = 0;

        public void SwapBuffers()
        {
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
