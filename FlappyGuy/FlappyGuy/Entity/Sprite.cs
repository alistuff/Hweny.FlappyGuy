using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hweny.FlappyGuy.Gfx;

namespace Hweny.FlappyGuy.Entity
{
    public class Sprite : GameEntity
    {
        public Image Surface
        {
            get;
            set;
        }
        public float Rotate
        {
            get;
            set;
        }
        public float Alpha
        {
            get;
            set;
        }
        public float Scale
        {
            get;
            set;
        }
        public float VelocityX
        {
            get;
            set;
        }
        public float VelocityY
        {
            get;
            set;
        }

        public Sprite()
            : base()
        {
            Surface = null;
            Rotate = 0f;
            Alpha = 1f;
            Scale = 1f;
        }

        public Sprite(Image surface)
            : base()
        {
            this.Surface = surface;
            this.Rotate = 0f;
            this.Alpha = 1f;
            this.Scale = 1f;
        }

        public Sprite(Image surface, float x, float y)
            : base(x, y)
        {
            this.Surface = surface;
            this.Rotate = 0f;
            this.Alpha = 1f;
            this.Scale = 1f;
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            this.X += VelocityX * elapsedSeconds;
            this.Y += VelocityY * elapsedSeconds;
        }

        public override void Render(System.Drawing.Graphics g)
        {
            if (Surface == null)
                return;

            GraphicsHelper.DrawImage(g, Surface, X, Y, Rotate,
                Scale, Alpha);
        }
    }
}
