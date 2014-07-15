using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hweny.FlappyGuy.Physics;
using System.Drawing;

namespace Hweny.FlappyGuy.Entity
{
    public class Foreground : Sprite, IBoundingBox
    {
        public Foreground(float speed)
            : base(MyGame.Assets.GetImage(MyAssetsLoader.IM_GROUND))
        {
            this.VelocityX = speed;
            this.Y = MyGame.HEIGHT - Surface.Height;
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            base.Update(gameTime, elapsedSeconds);
            if (this.X <= -Surface.Width)
            {
                this.X = 0;
            }
        }

        public override void Render(System.Drawing.Graphics g)
        {
            //scroll

            g.DrawImage
            (
                Surface,
                X,
                Y,
                Surface.Width,
                Surface.Height
            );

            g.DrawImage
            (
                Surface,
                X + Surface.Width - 1,
                Y,
                Surface.Width,
                Surface.Height
            );
        }

        public System.Drawing.Rectangle BoundingBox
        {
            get
            {
                Rectangle boundingBox = new Rectangle(0, MyGame.HEIGHT - Surface.Height + 20,
                    Surface.Width, Surface.Height);
                return boundingBox;
            }
        }
    }
}
