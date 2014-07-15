using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hweny.FlappyGuy.Physics;

namespace Hweny.FlappyGuy.Entity
{
    public class Pipe : Sprite, IBoundingBox
    {
        public bool IsCheck
        {
            get;
            set;
        }

        public Pipe(int x, int y, float speed)
            : base(MyGame.Assets.GetImage(MyAssetsLoader.IM_PIPE), x, y)
        {
            this.VelocityX = speed;
        }

        public Rectangle BoundingBox
        {
            get
            {
                Rectangle boundingBox = Rectangle.Empty;
                boundingBox.X = (int)X;
                boundingBox.Y = Math.Max(0, (int)Y);
                boundingBox.Width = Surface.Width;
                if (Y < 0)
                    boundingBox.Height = Surface.Height + (int)Y;
                else
                    boundingBox.Height = MyGame.HEIGHT - (int)Y;
                boundingBox.Inflate(-4, -4);
                return boundingBox;
            }
        }
    }
}
