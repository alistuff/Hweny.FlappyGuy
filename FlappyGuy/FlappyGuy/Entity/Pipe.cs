using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hweny.FlappyGuy.Physics;

namespace Hweny.FlappyGuy.Entity
{
    public class Pipe:GameEntity,IBoundingBox
    {
        private float speed;

        public bool IsCheck
        {
            get;
            set;
        }

        public Pipe(int x, int y, float speed)
            : base(x, y)
        {
            this.speed = speed;
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            X += speed * elapsedSeconds;
        }

        public override void Render(Graphics g)
        {
            g.DrawImage(MyGame.ASSETS_PIPE, X, Y, MyGame.ASSETS_PIPE.Width, MyGame.ASSETS_PIPE.Height);
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle boundingBox = Rectangle.Empty;
                boundingBox.X = (int)X;
                boundingBox.Y = Math.Max(0,(int)Y);
                boundingBox.Width = MyGame.ASSETS_PIPE.Width;
                if (Y < 0)
                    boundingBox.Height = MyGame.ASSETS_PIPE.Height + (int)Y;
                else
                    boundingBox.Height = MyGame.HEIGHT - (int)Y;
                boundingBox.Inflate(-4, -4);
                return boundingBox;
            }
        }
    }
}
