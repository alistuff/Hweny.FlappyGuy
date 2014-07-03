using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Hweny.FlappyGuy.Input;

namespace Hweny.FlappyGuy.Scene
{
    public class GameMenuScene : GameScene, IKeyListener
    {

        public override void Initialize()
        {
            AddKeyListener(this);
        }

        public override void Update(float gameTime, float elapsedSeconds)
        {

        }

        public override void Render(Graphics g)
        {
            g.Clear(Color.Black);
            using (Font font = new Font("微软雅黑", 35, FontStyle.Bold))
            {
                g.DrawString("Flappy Guy", font, Brushes.Snow, 10, 40);
            }
            using (Font font = new Font("微软雅黑", 12, FontStyle.Italic))
            {
                g.DrawString("Version 1.0", font, Brushes.Snow, 50, 160);
                g.DrawString("Programming & Graphics", font, Brushes.Snow, 50, 180);
                g.DrawString("——ALi", font, Brushes.Snow, 150, 210);
            }
            using (Font font = new Font("微软雅黑", 11, FontStyle.Italic))
            {
                g.DrawString("[Press any key to continue]", font, Brushes.Linen, 60, MyGame.HEIGHT - 50);
            }
        }

        public void KeyPressed(System.Windows.Forms.KeyEventArgs e)
        {
            Gsm.Replace(MyGame.SCENE_PLAY);
        }

        public void KeyReleased(System.Windows.Forms.KeyEventArgs e)
        {

        }
    }
}
