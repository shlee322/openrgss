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

        private const string RubyExtensionSource = @"
            require 'OpenRGSS.Runtime.RGSS'
            include OpenRGSS::Runtime::RGSS

            class Input
	            class << self
		            def trigger?(num)
			            return triggerQM(num.getKey())
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
        ";
        private const string ScriptLoaderSource = @"
            load_assembly 'IronRuby.Libraries', 'IronRuby.StandardLibrary.Zlib'

            f = File.open('Data/Scripts.rxdata', 'rb')
            obj = Marshal.load(f)
            for script in obj
                Engine.LoadScript(script[1], Zlib::Inflate.inflate(script[2]))
            end
        ";

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
            GL.Viewport(0, 0, 640, 480);
            GL.Ortho(0.0, 640, 480, 0, 1, -1);
            GL.Enable(EnableCap.Texture2D);
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
            this.LoadScript("RubyExtensionSource", Engine.RubyExtensionSource);
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

        public void SwapBuffers()
        {
            this.window.SwapBuffers();
        }
    }
}
