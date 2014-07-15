using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hweny.FlappyGuy.Entity
{
    public class Background : Sprite
    {
        public Background()
            : base(MyGame.Assets.GetImage(MyAssetsLoader.IM_BACKGROUND))
        {

        }

        public override void Render(System.Drawing.Graphics g)
        {
            g.DrawImage
                (
                    Surface,
                    0,
                    MyGame.HEIGHT - Surface.Height - 24,
                    Surface.Width,
                    Surface.Height
                );
        }
    }
}
