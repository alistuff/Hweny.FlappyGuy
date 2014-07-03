using System;
using System.Collections.Generic;
using System.Drawing;
using Hweny.FlappyGuy.Entity;
using Hweny.FlappyGuy.Input;
using System.Windows.Forms;

namespace Hweny.FlappyGuy.Scene
{
    public class GamePlayScene : GameScene, IKeyListener, IMouseListener
    {
        private const float SPEED = -80.5f;

        public IList<GameEntity> WorldObjs { get; private set; }

        private Player player;
        private Background background;
        private Foreground foreground;
        private IList<Pipe> pipes = new List<Pipe>();

        private PlayerInput playerInput;
        private ScoreRecord score;

        private Random random = new Random();
        private bool isGameOver = false;
        private bool isReady = false;

        public GamePlayScene(ScoreRecord score)
        {
            this.score = score;
            WorldObjs = new List<GameEntity>();
        }

        public override void Initialize()
        {
            player = new Player(this);
            playerInput = new PlayerInput(player);
            AddMouseListener(playerInput);
            AddKeyListener(playerInput);
            AddMouseListener(this);
            AddKeyListener(this);

            background = new Background();
            foreground = new Foreground(SPEED);

            for (int i = 0; i < 6; i++)
            {
                Pipe pipe = new Pipe(0, 0, SPEED);
                pipes.Add(pipe);
            }

            //GameObjects Manager
            WorldObjs.Add(background);
            WorldObjs.Add(foreground);
            foreach (Pipe pipe in pipes)
            {
                WorldObjs.Add(pipe);
            }
            WorldObjs.Add(player);
        }
        public override void OnEnter()
        {
            base.OnEnter();

            //reset player
            player.Reset();

            //reset the pipes
            for (int i = 0; i < 3; i++)
            {
                pipes[i].X = (MyGame.WIDTH + MyGame.WIDTH / 2) + i * 160;
                pipes[i].Y = -random.Next(150, 301);
                pipes[i].IsCheck = false;
                pipes[i + 3].X = pipes[i].X;
                pipes[i + 3].Y = MyGame.HEIGHT + pipes[i].Y;
            }

            //reset the foreground
            foreground.X = 0;

            //reset score
            score.Reset();

            isReady = false;
            isGameOver = false;
        }
        public override void Update(float gameTime, float elapsedSeconds)
        {
            if (!isReady)
                return;

            if (!isGameOver)
            {
                foreach (GameEntity obj in WorldObjs)
                {
                    obj.Update(gameTime, elapsedSeconds);
                }

                for (int i = 0; i < 3; i++)
                {
                    if (player.X >= pipes[i].X && !pipes[i].IsCheck)
                    {
                        score.Increase();
                        pipes[i].IsCheck = true;
                    }

                    if (pipes[i].X < -MyGame.ASSETS_PIPE.Width)
                    {
                        pipes[i].X = MyGame.WIDTH + 90;
                        pipes[i].Y = -random.Next(150, 301);
                        pipes[i].IsCheck = false;
                        pipes[i + 3].X = pipes[i].X;
                        pipes[i + 3].Y = MyGame.HEIGHT + pipes[i].Y;
                    }
                }

                if (player.IsDie())
                    isGameOver = true;
            }
            else
            {
                player.Update(gameTime, elapsedSeconds);
                if (player.Y >= foreground.Y)
                {
                    System.Threading.Thread.Sleep(500);
                    Gsm.Push(MyGame.SCENE_OVER);
                }
            }
        }
        public override void Render(Graphics g)
        {
            foreach (GameEntity obj in WorldObjs)
            {
                obj.Render(g);
            }

            score.Render(g);

            if (!isReady)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(168, 0, 0, 0)))
                {
                    g.FillRectangle(brush, 0, 0, 480, 640);
                }
                g.DrawString("Mouse Click \n[W,↑,SPACE]",
                    new Font("微软雅黑", 25, FontStyle.Bold), System.Drawing.Brushes.White, 55, 150);
            }
        }

        public void KeyPressed(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Space || e.KeyCode == Keys.W)
                isReady = true;
        }
        public void KeyReleased(KeyEventArgs e) { }
        public void MousePressed(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isReady = true;
        }
        public void MouseMoved(MouseEventArgs e)
        {
        }
        public void MouseReleased(MouseEventArgs e)
        {

        }
    }
}
