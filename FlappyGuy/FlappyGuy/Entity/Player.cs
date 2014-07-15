using System.Collections.Generic;
using System.Drawing;
using Hweny.FlappyGuy.Physics;
using Hweny.FlappyGuy.Gfx;
using Hweny.FlappyGuy.Scene;

namespace Hweny.FlappyGuy.Entity
{
    public class Player : Sprite, IBoundingBox
    {
        private IList<GameEntity> worldObjs;
        //physics
        private const float GRAVITY = 350f;
        private const float LIFT = -200;
        private const float RISE_ROTATE = -10f;
        private const float DOWN_ROTATE = 30;

        private int width;
        private int height;

        //animation
        private const int NUM_OF_FRAMERS = 2;
        private int currentFrame;
        private float frameTime = 1.0f / 20;
        private float accumulatedFrameTime = 0.0f;

        //state
        private bool isFlap = false;
        private bool isHit = false;
        private bool isDie = false;

        public Player(GamePlayScene world)
            : base(MyGame.Assets.GetImage(MyAssetsLoader.IM_PLAYER))
        {
            width = Surface.Width / NUM_OF_FRAMERS;
            height = Surface.Height;

            this.worldObjs = world.WorldObjs;
            Reset();
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            //animation
            accumulatedFrameTime += elapsedSeconds;
            if (accumulatedFrameTime > frameTime)
            {
                accumulatedFrameTime -= frameTime;
                currentFrame = (currentFrame + 1) % NUM_OF_FRAMERS;
            }

            //player update
            if (!isHit && isFlap)
            {
                Rotate = RISE_ROTATE;
                VelocityY = LIFT;
                isFlap = false;
            }
            else if (isHit && !isDie)
            {
                VelocityY = LIFT / 2;
                isDie = true;
            }
            else
            {
                Rotate += DOWN_ROTATE * elapsedSeconds;
            }

            VelocityY += GRAVITY * elapsedSeconds;
            // Y += velocityY * elapsedSeconds;

            base.Update(gameTime, elapsedSeconds);

            //collision check
            if (!isHit)
            {
                if ((CollisionWith(worldObjs) || Y < -height))
                {
                    isHit = true;
                }
            }
        }
        public override void Render(Graphics g)
        {
            GraphicsHelper.DrawImage
            (
                g,
                Surface,
                new RectangleF(X, Y, width, height),
                new RectangleF(currentFrame * width, 0, width, height),
                Rotate
            );
        }
        public void Reset()
        {
            X = 100;
            Y = 80;
            VelocityY = 0;
            Rotate = 0;
            isFlap = false;
            isHit = false;
            isDie = false;
        }
        public void Flap()
        {
            isFlap = true;
        }
        public bool IsDie()
        {
            return isDie;
        }
        public Rectangle BoundingBox
        {
            get
            {
                Rectangle boundingBox = new Rectangle((int)X, (int)Y, width, height);
                boundingBox.Inflate(-2, -2);
                return boundingBox;
            }
        }

        private bool CollisionWith(IList<GameEntity> others)
        {
            foreach (GameEntity obj in others)
            {
                if (obj == this) continue;
                IBoundingBox box = obj as IBoundingBox;
                if (box != null)
                {
                    if (BoundingBox.IntersectsWith(box.BoundingBox))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
