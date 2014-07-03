using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hweny.FlappyGuy.Physics;
using System.Drawing;

namespace Hweny.FlappyGuy.Entity
{
    public class Foreground : GameEntity, IBoundingBox
    {
        private const float SPEED = -80.5f;

        private float speed;
        public Foreground(float speed)
            : base()
        {
            this.speed = speed;
            this.Y = MyGame.HEIGHT - MyGame.ASSETS_GROUND.Height;
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            this.X += speed * elapsedSeconds;
            if (this.X <= -MyGame.ASSETS_GROUND.Width)
            {
                this.X = 0;
            }
        }

        public override void Render(System.Drawing.Graphics g)
        {
            //scroll

            g.DrawImage
            (
                MyGame.ASSETS_GROUND,
                X,
                Y,
                MyGame.ASSETS_GROUND.Width,
                MyGame.ASSETS_GROUND.Height
            );

            g.DrawImage
            (
                MyGame.ASSETS_GROUND,
                X + MyGame.ASSETS_GROUND.Width - 1,
                Y,
                MyGame.ASSETS_GROUND.Width,
                MyGame.ASSETS_GROUND.Height
            );
        }

        public System.Drawing.Rectangle BoundingBox
        {
            get
            {
                Rectangle boundingBox = new Rectangle(0, MyGame.HEIGHT - MyGame.ASSETS_GROUND.Height+20,
                    MyGame.ASSETS_GROUND.Width, MyGame.ASSETS_GROUND.Height);
                return boundingBox;
            }
        }
    }
}
