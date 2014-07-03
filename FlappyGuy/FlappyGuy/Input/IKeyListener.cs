using System.Windows.Forms;

namespace Hweny.FlappyGuy.Input
{
    public interface IKeyListener
    {
        void KeyPressed(KeyEventArgs e);
        void KeyReleased(KeyEventArgs e);
    }
}
