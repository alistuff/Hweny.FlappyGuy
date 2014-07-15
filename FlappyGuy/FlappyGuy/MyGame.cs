using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Hweny.FlappyGuy.Main;
using Hweny.FlappyGuy.Scene;
using Hweny.FlappyGuy.Entity;

namespace Hweny.FlappyGuy
{
    public class MyGame : Game
    {
        //Game
        public const int WIDTH = 320;
        public const int HEIGHT = 480;
        public const string TITLE = "[LI-Games]-FlappyGuy";

        //Scenes
        public const string SCENE_LOGO = "logo";
        public const string SCENE_MENU = "menu";
        public const string SCENE_PLAY = "play";
        public const string SCENE_OVER = "over";

        //Assets
        public static MyAssetsLoader Assets;

        //score
        private ScoreRecord score = new ScoreRecord();
        private const string SAVE_FILE = "Assets/data.wrd";

        protected override void LoadContent()
        {
            //load assets
            Assets = new MyAssetsLoader();
            Assets.LoadAssets();

            //load data
            this.score.Load(SAVE_FILE);
        }

        protected override void UnLoadContent()
        {
            //unload assets
            Assets.Dispose();

            //save data
            this.score.Save(SAVE_FILE);
        }

        protected override void Initialize()
        {
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.Title = TITLE;
            this.TargetFps = 60;
            this.Window.ShowIcon = true;
            this.Window.Icon = new Icon("Assets/Gfx/32.ico");

            this.Gsm.Add(SCENE_LOGO, new GameLogoScene());
            this.Gsm.Add(SCENE_MENU, new GameMenuScene());
            this.Gsm.Add(SCENE_PLAY, new GamePlayScene(score));
            this.Gsm.Add(SCENE_OVER, new GameOverScene(score));
            this.Gsm.Push(SCENE_LOGO);
        }
    }
}
