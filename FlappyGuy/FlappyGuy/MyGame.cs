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
        public static Image ASSETS_LOGO;
        public static Image ASSETS_GAMEOVER;
        public static Image ASSETS_PLAYER;
        public static Image ASSETS_PIPE;
        public static Image ASSETS_BACKGROUND;
        public static Image ASSETS_GROUND;
        public static Icon ASSETS_ICON;

        //score
        private ScoreRecord score = new ScoreRecord();
        private const string SAVE_FILE = "Assets/data.wrd";

        protected override void LoadContent()
        {
            //load images
            ASSETS_LOGO = LoadImage("logo.png");
            ASSETS_GAMEOVER = LoadImage("gameover.png");
            ASSETS_PLAYER = LoadImage("player.png");
            ASSETS_PIPE = LoadImage("pipe.png");
            ASSETS_BACKGROUND = LoadImage("background.png");
            ASSETS_GROUND = LoadImage("ground.png");
            ASSETS_ICON = new Icon("Assets/Gfx/32.ico");

            //load data
            this.score.Load(SAVE_FILE);
        }

        protected override void UnLoadContent()
        {
            //unload images
            ASSETS_LOGO.Dispose();
            ASSETS_LOGO = null;
            ASSETS_GAMEOVER.Dispose();
            ASSETS_GAMEOVER = null;
            ASSETS_PLAYER.Dispose();
            ASSETS_PLAYER = null;
            ASSETS_PIPE.Dispose();
            ASSETS_PIPE = null;
            ASSETS_BACKGROUND.Dispose();
            ASSETS_BACKGROUND = null;
            ASSETS_GROUND.Dispose();
            ASSETS_GROUND = null;
            ASSETS_ICON.Dispose();
            ASSETS_ICON = null;

            //save data
            this.score.Save(SAVE_FILE);
        }

        protected override void Initialize()
        {
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.Title = TITLE;
            this.Window.ShowIcon = true;
            this.Window.Icon = ASSETS_ICON;

            this.Gsm.Add(SCENE_LOGO, new GameLogoScene());
            this.Gsm.Add(SCENE_MENU, new GameMenuScene());
            this.Gsm.Add(SCENE_PLAY, new GamePlayScene(score));
            this.Gsm.Add(SCENE_OVER, new GameOverScene(score));
            this.Gsm.Push(SCENE_LOGO);
        }

        private Image LoadImage(string fileName)
        {
            return Image.FromFile("Assets/Gfx/" + fileName);
        }
    }
}
