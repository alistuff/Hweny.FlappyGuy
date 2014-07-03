using System.Windows.Forms;

namespace Hweny.FlappyGuy.Input
{
    public interface IMouseListener
    {
        void MousePressed(MouseEventArgs e);
        void MouseMoved(MouseEventArgs e);
        void MouseReleased(MouseEventArgs e);
    }
}
