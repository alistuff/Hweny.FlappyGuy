using System.Collections.Generic;
using Hweny.FlappyGuy.Input;

namespace Hweny.FlappyGuy.Scene
{
    public abstract class GameScene
    {
        private IList<IMouseListener> mouseListeners = new List<IMouseListener>();
        private IList<IKeyListener> keyListeners = new List<IKeyListener>();

        protected internal GameSceneManager Gsm { get; set; }

        public GameScene()
        {

        }

        public abstract void Initialize();
        public abstract void Update(float gameTime, float elapsedSeconds);
        public abstract void Render(System.Drawing.Graphics g);

        public virtual void OnEnter() { }
        public virtual void OnLeave() { }

        public IEnumerable<IMouseListener> MouseListeners
        {
            get { return mouseListeners; }
        }
        public IEnumerable<IKeyListener> KeyListeners
        {
            get { return keyListeners; }
        }
        public void AddKeyListener(IKeyListener listener)
        {
            if (keyListeners.Contains(listener))
                return;

            keyListeners.Add(listener);
        }
        public void AddMouseListener(IMouseListener listener)
        {
            if (mouseListeners.Contains(listener))
                return;

            mouseListeners.Add(listener);
        }
    }
}
