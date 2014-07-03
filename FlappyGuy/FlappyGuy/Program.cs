using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hweny.FlappyGuy;

namespace FlappyGuy
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //run game
            var game = new MyGame();
            game.Run();
        }
    }
}
