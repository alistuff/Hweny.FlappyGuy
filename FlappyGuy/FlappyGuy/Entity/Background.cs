using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hweny.FlappyGuy.Entity
{
    public class Background : GameEntity
    {
        public Background()
            : base()
        {
  
        }
    
        public override void Update(float gameTime, float elapsedSeconds)
        {

        }

        public override void Render(System.Drawing.Graphics g)
        {
            g.Clear(System.Drawing.Color.FromArgb(80, 80, 80));

            g.DrawImage
                (
                    MyGame.ASSETS_BACKGROUND, 
                    0, 
                    MyGame.HEIGHT - MyGame.ASSETS_BACKGROUND.Height-MyGame.ASSETS_GROUND.Height/2,
                    MyGame.ASSETS_BACKGROUND.Width,
                    MyGame.ASSETS_BACKGROUND.Height
                );
        }
    }
}
