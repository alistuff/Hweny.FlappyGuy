using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hweny.FlappyGuy.Gfx;

namespace Hweny.FlappyGuy.Scene
{
    public class GameLogoScene : GameScene
    {
        enum LogoState
        {
            FadeIn,
            FadeOut
        }

        private const string LOGO_TEXT = "Code  for  fun:) ";
        private float alpha = 0f;
        private float rotate = -10f;
        private int textIndex = 0;
        private float accumulatedFrameTime = 0f;
        private float frameTime = 1.0f / 10;
        private LogoState state = LogoState.FadeIn;

        public override void Initialize()
        {

        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            switch (state)
            {
                case LogoState.FadeIn:
                    FadeIn(elapsedSeconds);
                    break;
                case LogoState.FadeOut:
                    FadeOut(elapsedSeconds);
                    break;
                default:
                    break;
            }
        }

        public override void Render(System.Drawing.Graphics g)
        {
            g.Clear(Color.Black);

            if (state==LogoState.FadeIn)
                GraphicsHelper.DrawImage(g, MyGame.Assets.GetImage(MyAssetsLoader.IM_LOGO),50, 40,rotate, alpha, alpha);

            if (state == LogoState.FadeOut)
                GraphicsHelper.DrawImage(g, MyGame.Assets.GetImage(MyAssetsLoader.IM_LOGO), 50, 40, rotate, 1f, alpha);

            if (textIndex > 0)
            {
                using (Font f = new Font("微软雅黑", 15, FontStyle.Bold))
                {
                    if (textIndex < LOGO_TEXT.Length)
                        g.DrawString(LOGO_TEXT.Substring(0, textIndex), f, Brushes.Snow, 75, 220);
                    else
                        g.DrawString(LOGO_TEXT, f, Brushes.Snow, 75, 220);
                }
            }
        }

        private void FadeIn(float elapsedSeconds)
        {
            alpha = Math.Min(1f, alpha + 0.5f*elapsedSeconds);

            if (alpha >= 1f)
            {
                accumulatedFrameTime+=elapsedSeconds;
                if (accumulatedFrameTime > frameTime)
                {
                    accumulatedFrameTime -= frameTime;
                    textIndex = Math.Min(LOGO_TEXT.Length, textIndex + 1);
                }
                rotate = Math.Min(30, rotate + 20f * elapsedSeconds);
            }

            if (textIndex >= LOGO_TEXT.Length)
            {
                state = LogoState.FadeOut; 
                System.Threading.Thread.Sleep(100);
                accumulatedFrameTime = 0f;
            }
        }

        private void FadeOut(float elapsedSeconds)
        {
            accumulatedFrameTime += elapsedSeconds;
            if (accumulatedFrameTime > frameTime)
            {
                accumulatedFrameTime -= frameTime;
                textIndex = Math.Max(0, textIndex - 1);
            }
            if (textIndex <= 0)
            {
                alpha = Math.Max(0f, alpha - 0.5f * elapsedSeconds);
                if (alpha <= 0f)
                {
                    Gsm.Replace(MyGame.SCENE_MENU);
                }
            }
        }
    }
}
