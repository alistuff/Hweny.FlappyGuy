using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hweny.FlappyGuy.Main;

namespace Hweny.FlappyGuy
{
    public class MyAssetsLoader : AssetsLoader
    {
        public const string IM_LOGO = "LOGO";
        public const string IM_GAMEOVER = "GAMEOVER";
        public const string IM_PLAYER = "PLAYER";
        public const string IM_PIPE = "PIPE";
        public const string IM_BACKGROUND = "BACKGROUND";
        public const string IM_GROUND = "GROUND";

        public override void LoadAssets()
        {
            this.AddImage(IM_LOGO, "logo.png");
            this.AddImage(IM_GAMEOVER, "gameover.png");
            this.AddImage(IM_PLAYER, "player.png");
            this.AddImage(IM_PIPE, "pipe.png");
            this.AddImage(IM_BACKGROUND, "background.png");
            this.AddImage(IM_GROUND, "ground.png");
        }

        protected override void AddImage(string key, string fileName)
        {
            base.AddImage(key, "Assets/Gfx/" + fileName);
        }
    }
}
