/* 
 * ///////////////////////////////////////////////////////////////////// 
 * Filename: Game.cs 
 * Author  : [LI-Games.ALi][alistuff@163.com] 
 * Date    : 2014/7/3    
 * Resume  : 游戏类，提供游戏初始化、更新和渲染等操作。
 *  
 * ///////////////////////////////////////////////////////////////////// 
 * Modifiy History 
 *  
 * Date    : 
 * Resume  : 
 *  
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Hweny.FlappyGuy.Scene;

namespace Hweny.FlappyGuy.Main
{
    public abstract class Game
    {
        private const int DEFAULT_WIDTH = 480;
        private const int DEFAULT_HEIGHT = 320;
        private const int DEFAULT_FPS = 60;

        private Bitmap bufferBitmap;
        private bool isRunning = false;

        protected string Title 
        { 
            get;
            set; 
        }
        protected int Width
        {
            get;
            set;
        }
        protected int Height
        {
            get;
            set;
        }
        protected int TargetFps
        {
            get;
            set;
        }
        protected GameWindow Window 
        {
            get; 
            private set; 
        }
        protected GameSceneManager Gsm
        {
            get;
            private set;
        }

        protected Game()
        {
            Title = "LI-Games";
            Width = DEFAULT_WIDTH;
            Height = DEFAULT_HEIGHT;
            TargetFps = DEFAULT_FPS;

            Gsm = new GameSceneManager();
        }

        public void Run()
        {
            if (!isRunning)
            {
                isRunning = true;

                Window = new GameWindow();
                //Window Events
                Window.WndStartup += new EventHandler<EventArgs>(Window_WndStartup);
                Window.WndUpdate += new EventHandler<UpdateFrameEventArgs>(Window_WndUpdate);
                Window.WndRender += new EventHandler<RenderFrameEventArgs>(Window_WndRender);
                Window.WndCleanup += new EventHandler<EventArgs>(Window_WndCleanup);
                //Keybord Events
                Window.WndKeyUp += new EventHandler<KeyEventArgs>(Window_WndKeyUp);
                Window.WndKeyDown += new EventHandler<KeyEventArgs>(Window_WndKeyDown);
                //Mouse Events
                Window.WndMouseUp += new EventHandler<MouseEventArgs>(Window_WndMouseUp);
                Window.WndMouseMove += new EventHandler<MouseEventArgs>(Window_WndMouseMove);
                Window.WndMouseDown += new EventHandler<MouseEventArgs>(Window_WndMouseDown);

                Window.Run();
            }
        }

        protected abstract void LoadContent();
        protected abstract void UnLoadContent();
        protected abstract void Initialize();
        protected virtual void Update(float gameTime, float elapsedSeconds)
        {
            Gsm.Update(gameTime,elapsedSeconds);
        }
        protected virtual void Render(Graphics g)
        {
            Gsm.Render(g);
        }

        private void Window_WndStartup(object sender, EventArgs e)
        {
            LoadContent();
            Initialize();

            Window.Text = Title;
            Window.ClientSize = new Size(Width, Height);
            Window.TargetFps = TargetFps;

            bufferBitmap = new Bitmap(Width, Height);
        }
        private void Window_WndUpdate(object sender, UpdateFrameEventArgs e)
        {
            Update(e.GameTime, e.ElapsedSeconds);
        }
        private void Window_WndRender(object sender, RenderFrameEventArgs e)
        {
            //draw to buffer bitmap
            using (Graphics bufferGraphics = Graphics.FromImage(bufferBitmap))
            {
                Render(bufferGraphics);
            }
            //draw to screen
            Graphics screen = e.Graphics;
            screen.DrawImageUnscaled(bufferBitmap, 0, 0);
        }
        private void Window_WndCleanup(object sender, EventArgs e)
        {
            UnLoadContent();
            bufferBitmap.Dispose();
            bufferBitmap = null;

            Gsm = null;
        }
        private void Window_WndKeyDown(object sender, KeyEventArgs e)
        {
            Gsm.OnKeyPressed(e);
        }
        private void Window_WndKeyUp(object sender, KeyEventArgs e)
        {
            Gsm.OnKeyReleased(e);
        }
        private void Window_WndMouseDown(object sender, MouseEventArgs e)
        {
            Gsm.OnMousePressed(e);
        }
        private void Window_WndMouseMove(object sender, MouseEventArgs e)
        {
            Gsm.OnMouseMoved(e);
        }
        private void Window_WndMouseUp(object sender, MouseEventArgs e)
        {
            Gsm.OnMouseReleased(e);
        }
    }
}
