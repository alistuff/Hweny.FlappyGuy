using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Hweny.FlappyGuy.Input;

namespace Hweny.FlappyGuy.Scene
{
    public class GameSceneManager
    {
        private Dictionary<string, GameScene> scenes;
        private Stack<GameScene> stackScenes;

        private GameScene TopScene
        {
            get
            {
                if (stackScenes.Count > 0)
                    return stackScenes.Peek();
                return null;
            }
        }

        public GameSceneManager()
        {
            scenes = new Dictionary<string, GameScene>();
            stackScenes = new Stack<GameScene>();
        }

        public void Add(string key, GameScene scene)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key");

            if (scenes.Keys.Contains(key))
                throw new ArgumentException("key already exists");

            scene.Gsm = this;
            scene.Initialize();
            scenes.Add(key, scene);
        }
        public void Remove(string key)
        {
            if (scenes.Keys.Contains(key))
            {
                scenes.Remove(key);
            }
        }

        public void Replace(string sceneKey)
        {
            if (!scenes.Keys.Contains(sceneKey))
                throw new ArgumentException("sceneKey");

            Pop();
            Push(sceneKey);
        }
        public void Push(string sceneKey)
        {
            if (!scenes.Keys.Contains(sceneKey))
                throw new ArgumentException("sceneKey");

            if (stackScenes.Count > 0)
                stackScenes.Peek().OnLeave();

            GameScene scene = scenes[sceneKey];
            scene.OnEnter();
            stackScenes.Push(scene);
        }
        public void Pop()
        {
            if (TopScene != null)
            {
                TopScene.OnLeave();
                stackScenes.Pop();

                if (TopScene != null)
                {
                    TopScene.OnEnter();
                }
            }
        }

        public void Update(float gameTime, float elapsedSeconds)
        {
            if (TopScene != null)
            {
                TopScene.Update(gameTime, elapsedSeconds);
            }
        }
        public void Render(System.Drawing.Graphics g)
        {
            if (TopScene != null)
            {
                TopScene.Render(g);
            }
        }

        public void OnKeyPressed(KeyEventArgs e)
        {
            if (TopScene != null)
            {
                foreach (IKeyListener listener in TopScene.KeyListeners)
                {
                    listener.KeyPressed(e);
                }
            }
        }
        public void OnKeyReleased(KeyEventArgs e)
        {
            if (TopScene != null)
            {
                foreach (IKeyListener listener in TopScene.KeyListeners)
                {
                    listener.KeyReleased(e);
                }
            }
        }
        public void OnMousePressed(MouseEventArgs e)
        {
            if (TopScene != null)
            {
                foreach (IMouseListener listener in TopScene.MouseListeners)
                {
                    listener.MousePressed(e);
                }
            }
        }
        public void OnMouseMoved(MouseEventArgs e)
        {
            if (TopScene != null)
            {
                foreach (IMouseListener listener in TopScene.MouseListeners)
                {
                    listener.MouseMoved(e);
                }
            }
        }
        public void OnMouseReleased(MouseEventArgs e)
        {
            if (TopScene != null)
            {
                foreach (IMouseListener listener in TopScene.MouseListeners)
                {
                    listener.MouseReleased(e);
                }
            }
        }
    }
}
