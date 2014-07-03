using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Hweny.FlappyGuy.Entity
{
    public abstract class GameEntity
    {
        public float X 
        { 
            get;
            set; 
        }
        public float Y 
        { 
            get; 
            set; 
        }

        public GameEntity()
        {
            this.X = 0;
            this.Y = 0;
        }

        public GameEntity(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public abstract void Update(float gameTime, float elapsedSeconds);
        public abstract void Render(Graphics g);
    }
}
