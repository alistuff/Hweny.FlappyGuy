using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hweny.FlappyGuy.Input;
using System.Windows.Forms;

namespace Hweny.FlappyGuy.Entity
{
    public class PlayerInput : IMouseListener, IKeyListener
    {
        private Player player;
        private bool isKeyDown = false;

        public PlayerInput(Player player)
        {
            this.player = player;
        }

        public void MousePressed(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                player.Flap();
            }
        }
        public void MouseReleased(MouseEventArgs e)
        {

        }
        public void MouseMoved(MouseEventArgs e)
        {

        }
        public void KeyPressed(KeyEventArgs e)
        {
            if (!isKeyDown && (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode==Keys.Space))
            {
                isKeyDown = true;
                player.Flap();
            }
        }
        public void KeyReleased(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == Keys.Space)
            {
                isKeyDown = false;
            }
        }
    }
}
