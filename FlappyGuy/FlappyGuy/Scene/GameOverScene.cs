using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hweny.FlappyGuy.Input;
using System.Windows.Forms;
using Hweny.FlappyGuy.Entity;
using System.Drawing;

namespace Hweny.FlappyGuy.Scene
{
    public class GameOverScene : GameScene, IMouseListener, IKeyListener
    {
        private ScoreRecord score;
        private float offsetX;
        private float offsetY;

        public GameOverScene(ScoreRecord score)
        {
            this.score = score;
        }

        public override void Initialize()
        {
            AddMouseListener(this);
            AddKeyListener(this);

            offsetX = (MyGame.WIDTH - MyGame.ASSETS_GAMEOVER.Width) >> 1;
            offsetY = -MyGame.ASSETS_GAMEOVER.Height;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            offsetY = -MyGame.ASSETS_GAMEOVER.Height;
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {
            if (offsetY < 80)
                offsetY += 100 * elapsedSeconds;
        }

        public override void Render(System.Drawing.Graphics g)
        {
            g.Clear(System.Drawing.Color.FromArgb(60, 60, 60));
            g.DrawImage(MyGame.ASSETS_GAMEOVER, offsetX, offsetY, MyGame.ASSETS_GAMEOVER.Width, MyGame.ASSETS_GAMEOVER.Height);

            if (offsetY >= 80)
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                Rectangle clipBound = new Rectangle(0, (int)(offsetY + MyGame.ASSETS_GAMEOVER.Height), MyGame.WIDTH, 200);

                using (Font font = new Font("微软雅黑", 30f, FontStyle.Bold))
                {
                    g.DrawString(score.Score.ToString(), font, Brushes.White, clipBound, format);
                }
                using (Font font = new Font("微软雅黑", 16f, FontStyle.Italic))
                {
                    clipBound.Y += 55;
                    g.DrawString("HighScore：" + score.HighScore, font, Brushes.White, clipBound, format);
                }

                format.Dispose();
                format = null;
            }
        }

        public void MousePressed(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Gsm.Pop();
        }

        public void MouseMoved(MouseEventArgs e)
        {
        }

        public void MouseReleased(MouseEventArgs e)
        {

        }

        public void KeyPressed(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode==Keys.Space)
                Gsm.Pop();
        }

        public void KeyReleased(KeyEventArgs e)
        {
        }
    }
}
